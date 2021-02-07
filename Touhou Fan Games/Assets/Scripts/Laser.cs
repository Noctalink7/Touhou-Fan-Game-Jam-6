using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
            this.transform.GetChild(0).gameObject.SetActive(true);
    }
}
