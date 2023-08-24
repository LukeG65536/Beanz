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
        backPack["Beef Beans"] = new int[] { 0, 35 };
        backPack["Deep Fried Beans"] = new int[] { 0, 250 };
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
