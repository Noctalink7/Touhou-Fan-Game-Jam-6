using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Shot;
    public GameObject MultiShot;
    public GameObject BigShot;
    public GameObject SpeShot;

    private GameObject instance;
    public KeyCode TKey;
    float fireRate = 0.3f;
    private float nextFire = 0.0f;
    public Combo combo;

    // Start is called before the first frame update
    void Start()
    {
        instance = Shot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(TKey) && (Time.time > nextFire)) {
            InstanceShot();
            Instantiate(instance, this.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void InstanceShot()
    {
        if (combo.fus[0] == "Fire" && combo.fus[1] == "Fire")
            instance = MultiShot;
        else if (combo.fus[0] == "Earth" && combo.fus[1] == "Earth")
            instance = BigShot;
        else if ((combo.fus[0] == "Earth" && combo.fus[1] == "Fire") || (combo.fus[1] == "Earth" && combo.fus[0] == "Fire"))
            instance = SpeShot;
        else
            instance = Shot;
    }
}
