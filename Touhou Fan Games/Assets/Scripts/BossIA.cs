using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossIA : MonoBehaviour
{
    public float Health;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector3 vector;
    private Vector3 shotPlacement;
    private float timer;
    public GameObject Shot;
    private int nbAttack = 15;
    private bool isDead = false;
    public GameObject SpeShot;
    public GameObject laser;
    public GameObject WhiteFade;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 2;
        vector = new Vector3(-1.0f, 0.0f, 0.0f);
        shotPlacement = new Vector3(0.0f, -1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        BossDeath();
        if (!isDead)
        {
            Attack();
            ChangeDirection();
            Move();
        }
        else if (isDead && !stop)
        {
            stop = true;
            StartCoroutine(FadeCo());
        }
    }

    private void AttackMid()
    {
        if (nbAttack < 20)
            nbAttack = 20;
         StartCoroutine(SpeShoot());
    }

    IEnumerator SpeShoot()
    {
        for (int i = 0; i <= nbAttack; i++)
        {
            Vector3 position = new Vector3(Random.Range(3f, 5f), Random.Range(-3f, 4f), 0);
            Instantiate(SpeShot, position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void BossDeath()
    {
        if (Health <= 0)
        {
            isDead = true;
            Debug.Log("Boss is Dead");
        }
    }

    private void ChangeDirection() {
        if (transform.position.x >= 2)
            vector = new Vector3(-1.0f, 0.0f, 0.0f);
        else if (transform.position.x <= -8)
            vector = new Vector3(1.0f, 0.0f, 0.0f);
    }

    private void Move()
    {
        rb.MovePosition(transform.position + vector * moveSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        if (Time.time >= timer)
        {
            if (Health < 666f)
                AttackMid();
            if (Health < 333f)
                LaserAttack();
            StartCoroutine(Shoot());
            timer += 10;
        }
    }

    private void LaserAttack()
    {
        if (nbAttack < 20)
            nbAttack = 20;
        StartCoroutine(LaserShoot());
    }

    IEnumerator LaserShoot()
    {
        for (int i = 0; i <= 3; i++)
        {
            Vector3 position = new Vector3(0, Random.Range(-4f, 4f), 0);
            Instantiate(laser, position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i <= nbAttack; i++)
        {
            Instantiate(Shot, this.transform.position + shotPlacement, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerShot"))
        {
            Health -= 5;
        }
    }

    public IEnumerator FadeCo()
    {
        if (WhiteFade != null)
        {
            Instantiate(WhiteFade, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameOver");
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
