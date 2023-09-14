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
    public Dictionary<string, double[]> upgradesRebirth = new Dictionary<string, double[]>();
    public Dictionary<string, TextMeshProUGUI> buttons = new Dictionary<string, TextMeshProUGUI>();    
    public double cash = 0;
    public double cashR = 0;
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
        upgradesRebirth["Cash Multi R"] = new double[] { 1, .35, 1, 1.2 }; /// {value of upgrade, increase in value, cost, cost increase}
        upgradesRebirth["Bean Multi R"] = new double[] { 1, .50, 1, 1.5 };
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Button")){ buttons[obj.GetComponent<ButtonManager>().index] = obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); } ///Dont question it
        foreach (var obj in upgrades)
        {
            buttons[obj.Key].text = obj.Key + ": " + Math.Round(obj.Value[2]).ToString();
        }
        //Load();
        if (cash == 0)
        {
            cash = 120;//?
        }
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
            SaveUpgrades();
        }
        catch
        {
            Debug.Log("incorrect item tag");
        }
    }

    public void upgradeR(string itemTag)
    {
        try
        {
            double[] item = upgradesRebirth[itemTag];
            if (cashR < item[2])
            {
                Debug.Log("U cant buy this yet");
                return;
            }

            item[0] += item[1];
            cash -= item[2];
            item[2] = item[2] * item[3];
            buttons[itemTag].text = itemTag + ": " + Math.Round(item[2]).ToString();
            SaveUpgrades();
        }
        catch
        {
            Debug.Log("incorrect item tag");
        }
    }

    public void SaveUpgrades()
    {
        foreach(var item in upgradesRebirth)
        {
            for(int i = 0; i < 4; i++)
            {
                PlayerPrefs.SetFloat(item.Key + i, (float)item.Value[i]);
            }
        }
        PlayerPrefs.SetFloat("cash", (float)cash);
        PlayerPrefs.SetFloat("cashR", (float)cashR);
    }

    public void Load()
    {
        foreach(var item in upgrades)
        {
            for(int i = 0; i < 4; i++)
            {
                upgrades[item.Key][i] = PlayerPrefs.GetFloat(item.Key + i);
            }
        }
        cash = PlayerPrefs.GetFloat("cash");
        cashR = PlayerPrefs.GetFloat("cashR");
    }

    public void Rebirth()
    {
        if(cash < 1000000)
        {
            return;
        }
        resetInv();
        upgrades["Cash Multi"] = new double[] { 1, .35, 20, 1.2 }; /// {value of upgrade, increase in value, cost, cost increase}
        upgrades["Bean Multi"] = new double[] { 1, .50, 100, 1.5 };
        cashR += 10;
        cash = 0;
        SaveUpgrades();
    }
}
