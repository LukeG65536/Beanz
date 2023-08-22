using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public Dictionary<string, int> backPack = new Dictionary<string, int>();
    public int cash = 0;
    // Start is called before the first frame update
    void Start()
    {
        backPack["Tree Beans"] = 0;
        backPack["Black Beans"] = 0;
        backPack["Deep Fry Bean"] = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
