using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    private float timer;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
            Destroy(laser.gameObject);
    }
}
