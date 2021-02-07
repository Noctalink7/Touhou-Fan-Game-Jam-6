using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristals : MonoBehaviour
{
    public string type;
    public Combo combo;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 10;
    }

    void Update()
    {
        if (Time.time >= timer)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            combo.nb = !combo.nb;
            if (combo.nb)
                combo.fus[0] = type;
            else
                combo.fus[1] = type;
            Destroy(this.gameObject);
        }
    }
}
