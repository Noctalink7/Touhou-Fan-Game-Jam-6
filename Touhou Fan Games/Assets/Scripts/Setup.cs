using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public Combo combo;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < combo.fus.Count; i++)
            combo.fus[i] = "";
    }
}
