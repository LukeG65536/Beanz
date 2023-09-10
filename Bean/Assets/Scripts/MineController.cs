using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            makeLayer(-i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeLayer(float depth)
    {
        for(int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Instantiate(rock, transform.position + new Vector3(i,depth,j),Quaternion.identity);
            }
        }
    }
}
