using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeController : MonoBehaviour
{
    public float lifeTime = 0f;
    public int treeState = 3;
    public bool deepFry = false;
    public Material gold;
    public Material pure;

    private void Start()
    {
        
    }
    void Update()
    {
        lifeTime += Time.deltaTime * 5;
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
            if (treeState == 3)
            {
                if (deepFry)
                {
                    other.gameObject.GetComponent<PlayerInv>().backPack["Deep Fried Beans"][0] += 1;
                }
                else
                {
                    other.gameObject.GetComponent<PlayerInv>().backPack["Tree Beans"][0] += 1;
                }
            }
            if(Random.Range(1,11) == 10)
            {
                deepFry = true;
                transform.GetChild(0).GetComponent<MeshRenderer>().material = gold;
            }
            else
            {

                deepFry = false;
                transform.GetChild(0).GetComponent<MeshRenderer>().material = pure;
            }
            lifeTime = 0f;
            treeState = 0;
        }
    }
}
