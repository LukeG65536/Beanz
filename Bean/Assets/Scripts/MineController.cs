using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    public GameObject rock;
    public int[,,] map = new int[100, 200, 200]; //[layer,x,y]
    public GameObject[,,] rocks;
    int mapOffset = 100;
    // Start is called before the first frame update
    void Start()
    {
        rocks[0, 0, 0] = new GameObject();
        for(int i = 0; i < 100; i++)
        {
            makeLayer(i);
        }
        setLayer(0);
    }

    // Update is called once per frame

    void makeLayer(float depth)
    {
        for(int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 200; j++)
            {
                rocks[(int)depth, i + mapOffset, j + mapOffset] = Instantiate(rock, transform.position + new Vector3(i + mapOffset, depth, j + mapOffset), Quaternion.identity);
                
                RockController hh = rocks[(int)depth, i + mapOffset, j + mapOffset].GetComponent<RockController>();
                hh.localPos = new Vector3(depth, i, j);
                hh.mine = this;
                
                map[(int)depth, i + mapOffset, j + mapOffset] = 1;
            }
        }
    }

    void setLayer(int depth)
    {
        for (int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 200; j++)
            {
                rocks[depth, i, j].SetActive(true);
            }
        }
    }

    public void breakRock(float depth, int x, int y)
    {
        Debug.Log("hiii");
        try
        {
            map[(int)depth, x + mapOffset, y + mapOffset] = -1;
        }
        catch
        {
            Debug.Log("Invalid Chords");
        }
        smartAdd((int)depth + 1, x, y);
        smartAdd((int)depth -1, x, y);
        smartAdd((int)depth, x + 1, y);
        smartAdd((int)depth, x - 1, y);
        smartAdd((int)depth, x, y + 1);
        smartAdd((int)depth, x, y - 1);
    }

    void smartAdd(int depth, int x, int y)
    {
        if (depth >= 0 && map[depth, x + mapOffset, y + mapOffset] == -1)
        {
            //Debug.Log("smth here");
            return;
        }
        try
        {
            map[depth, x + mapOffset, y + mapOffset] = 1;

            /*GameObject ff = Instantiate(rock, transform.position + new Vector3(x, -depth, y), Quaternion.identity);
            RockController f = ff.GetComponent<RockController>();
            f.localPos = new Vector3(depth, x ,y);
            f.mine = this;*/
            rocks[depth, x, y].SetActive(true);
        }
        catch
        {
            //Debug.Log("nah");
        }
    }
}
