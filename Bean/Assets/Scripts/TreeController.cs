using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeController : MonoBehaviour
{
    public int treeState = 3;
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Debug.Log("Hi");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInv>().backPack["Tree Beans"] += 1;
            treeState = 1;
        }
    }
}
