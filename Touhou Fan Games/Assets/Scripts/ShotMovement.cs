using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector3 vector;
    private float TimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = Time.time + 2f;
      //  vector = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
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
