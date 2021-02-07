using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Scrolling : MonoBehaviour
{
    public float speed = 0.5f;

    void Start()
    {
    }

    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }

}
