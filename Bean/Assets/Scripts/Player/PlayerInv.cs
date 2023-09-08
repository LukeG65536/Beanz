using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInv : MonoBehaviour
{
    public Dictionary<string, int[]> backPack = new Dictionary<string, int[]>();
    public Dictionary<string, double[]> upgrades = new Dictionary<string, double[]>();
    public Dictionary<string, TextMeshProUGUI> buttons = new Dictionary<string, TextMeshProUGUI>();    
    public double cash = 0;
    // Start is called before the first frame update
    void Start()
    {
        backPack["Tree Beans"] = new int[] { 0, 15 };
        backPack["Black Beans"] = new int[] { 0, 10 };
        backPack["Beef Beans"] = new int[] { 0, 35 };
        backPack["Deep Fried Beans"] = new int[] { 0, 2000 };
        backPack["Rock Beans"] = new int[] { 0, 10 };
        
        backPack["Gem Bean0"] = new int[] { 0, 450 };
        backPack["Gem Bean1"] = new int[] { 0, 50 };
        backPack["Gem Bean2"] = new int[] { 0, 150 };
        backPack["Gem Bean3"] = new int[] { 0, 20 };
        backPack["Gem Bean4"] = new int[] { 0, 2000 };
        backPack["Gem Bean5"] = new int[] { 0, 200 };
        backPack["Gem Bean6"] = new int[] { 0, 100 };
        backPack["Gem Bean7"] = new int[] { 0, 500 };
        backPack["Gem Bean8"] = new int[] { 0, 1000 };



        upgrades["Cash Multi"] = new double[] { 1, .35 , 20, 1.2 }; /// {value of upgrade, increase in value, cost, cost increase}
        upgrades["Bean Multi"] = new double[] { 1, .50, 100, 1.5 };
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Button")){ buttons[obj.GetComponent<ButtonManager>().index] = obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); } ///Dont question it
        /*foreach (var obj in upgrades)
        {
            buttons[obj.Key].text = obj.Key + ": " + Math.Round(obj.Value[2]).ToString();
        }*/
    }
    public void resetInv()
    {
        foreach(var item in backPack)
        {
            item.Value[0] = 0;
        }
    }


    public void upgrade(string itemTag)
    {
        try
        {
            double[] item = upgrades[itemTag];
            if (cash < item[2])
            {
                Debug.Log("U cant buy this yet");
                return;
            }

            item[0] += item[1];
            cash -= item[2];
            item[2] = item[2] * item[3];
            buttons[itemTag].text = itemTag + ": " + Math.Round(item[2]).ToString();
        }
        catch
        {
            Debug.Log("incorrect item tag");
        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if(collision.collider.tag == "Rock")
        {
            collision.collider.gameObject.GetComponent<RockController>().hit(this);
        }
    }
}
