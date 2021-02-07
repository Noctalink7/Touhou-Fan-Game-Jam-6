using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printInfos : MonoBehaviour
{
    public PV pV;
    public Text Life;
    public Combo combo;
    public GameObject img;

    // Start is called before the first frame update
    void Start()
    {
        pV.HP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Life.text = "PV : " + pV.HP;
        ActivateImg();
    }

    private void ActivateImg()
    {
        for (int i = 0; i < 2; i++)
        {
            if (combo.fus[i] == "Fire")
            {
                img.transform.GetChild(i * 2).gameObject.SetActive(true);
                img.transform.GetChild(i * 2 + 1).gameObject.SetActive(false);
            }
            else if (combo.fus[i] == "Earth")
            {
                img.transform.GetChild(i * 2 + 1).gameObject.SetActive(true);
                img.transform.GetChild(i * 2).gameObject.SetActive(false);
            }
        }
    }
}
