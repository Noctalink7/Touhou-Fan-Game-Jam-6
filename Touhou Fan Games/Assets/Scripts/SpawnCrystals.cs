using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrystals : MonoBehaviour
{
    public GameObject fire;
    public GameObject earth;
    private float timer;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 15;
    }

    // Update is called once per frame
    void Update()
    {
        i = Random.Range(0, 10);
        if (Time.time >= timer)
        {
            Vector3 position = new Vector3(Random.Range(-8.4f, 2.5f), Random.Range(-4.47f, 4.5f), 0);
            if (i < 5)
            {
                Instantiate(fire, position, Quaternion.identity);
            }
            else
            {
                Instantiate(earth, position, Quaternion.identity);
            }
            timer += 15;
        }
    }
}
