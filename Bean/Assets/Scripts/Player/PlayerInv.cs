using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public Dictionary<string, int[]> backPack = new Dictionary<string, int[]>();
    public int cash = 0;
    // Start is called before the first frame update
    void Start()
    {
        backPack["Tree Beans"] = new int[] { 0, 15 };
        backPack["Black Beans"] = new int[] { 0, 10 };
        backPack["Deep Fry Bean"] = new int[] { 0, 100 };
    }

    // Update is called once per frame
    public void resetInv()
    {
        foreach(var item in backPack)
        {
            item.Value[0] = 0;
        }
    }
}