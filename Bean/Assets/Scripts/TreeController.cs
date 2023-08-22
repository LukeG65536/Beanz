using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeController : MonoBehaviour
{
    float lifeTime = 0f;
    void Update()
    {
        lifeTime += Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Debug.Log("Hi");
            other.gameObject.GetComponent<PlayerInv>().backPack["Tree Beans"] += 1;
            lifeTime = 0f;
        }
    }
}
