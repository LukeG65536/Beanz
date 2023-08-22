using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeController : MonoBehaviour
{
    public float lifeTime = 0f;
    public int treeState = 3;
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(20 >= lifeTime && lifeTime >= 10)
        {
            treeState = 1;
            gameObject.transform.localScale = new Vector3(1, 1, 1) * 2f;
        }else if(30 >= lifeTime && lifeTime >= 20)
        {
            treeState = 2;
            gameObject.transform.localScale = new Vector3(1, 1, 1) * 4f;
        }else if(lifeTime > 30)
        {
            treeState = 3;
            gameObject.transform.localScale = new Vector3(1, 1, 1) * 8f;
        }
        else
        {
            treeState = 0;
            gameObject.transform.localScale = new Vector3();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (treeState >= 3) other.gameObject.GetComponent<PlayerInv>().backPack["Tree Beans"] += 1;
            lifeTime = 0f;
            treeState = 0;
        }
    }
}
