using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;

public enum PlayerState
{
    walk,
    interact,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Animator animator;
    private Vector3 change;

  //  public KeyCode UpKey, DownKey, RightKey, LeftKey;

    void Start()
    {
        currentState = PlayerState.idle;
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }
    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (rb.velocity != Vector2.zero)
            rb.velocity = Vector2.zero;
        if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
        else if (currentState == PlayerState.interact)
        {
            animator.SetBool("moving", false);
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            currentState = PlayerState.walk;
        }
        else
        {
            animator.SetBool("moving", false);
            currentState = PlayerState.idle;
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        rb.MovePosition(transform.position + change * moveSpeed * Time.deltaTime);
    }
}
