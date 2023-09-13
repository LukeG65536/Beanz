using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MineController : MonoBehaviour
{
    public GameObject rock;
    public int[,,] map = new int[100, 100, 100]; //[layer,x,y]
    public GameObject[,,] rocks = new GameObject[100,100,100];
    int mapOffset = 50;
    // Start is called before the first frame update
    void Start()
    {
        makeLayer(0);
    }

    // Update is called once per frame

    void makeLayer(float depth)
    {
        //GameObject[,] hhhh;
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                //rocks[(int)depth, i + mapOffset, j + mapOffset]
                //hhhh[i, j] = hhh;

                GameObject hhh = Instantiate(rock, transform.position + new Vector3(i, depth, j), Quaternion.identity);
                //hhh.SetActive(true);
                //rocks[(int)depth, i, j] = hhh;
                RockController hh = hhh.GetComponent<RockController>();
                hh.localPos = new Vector3(depth, i, j);
                hh.mine = this;

                map[(int)depth, i, j] = 1;
            }
        }
        //rocks = plus(rocks,hhhh);
    }

    void setLayer(int depth)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
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
        smartAdd((int)depth - 1, x, y);
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
            //map[depth, x + mapOffset, y + mapOffset] = 1;

            GameObject ff = Instantiate(rock, transform.position + new Vector3(x, -depth, y), Quaternion.identity);
            //ff.SetActive(true);
            RockController f = ff.GetComponent<RockController>();
            f.localPos = new Vector3(depth, x ,y);
            f.mine = this;
            //rocks[depth, x + mapOffset, y + mapOffset].SetActive(true);
        }
        catch
        {
            //Debug.Log("nah");
        }
    }
}
