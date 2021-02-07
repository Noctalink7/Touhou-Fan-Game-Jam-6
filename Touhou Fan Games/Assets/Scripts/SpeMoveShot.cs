using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeMoveShot : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector3 vector;
    private float TimeLeft;
    private float timer;
    public bool Right;

    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = Time.time + 4f;
        timer = Time.time + 0.2f ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
        {
            if (Right)
                vector.y = -vector.y;
            else
                vector.x = -vector.x;
            timer += 0.2f;
        }
        rb.MovePosition(transform.position + vector * moveSpeed * Time.deltaTime);
        if (Time.time >= TimeLeft)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Boss") && this.CompareTag("PlayerShot"))
        {
            Destroy(this.gameObject);
        }
    }
}
