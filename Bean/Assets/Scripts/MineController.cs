using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    public GameObject rock;
    public int[,,] map = new int[1000, 200, 200]; //[layer,x,y]
    public int mapOffsetX = 100;
    public int mapOffsetY = 100;
    // Start is called before the first frame update
    void Start()
    {
        makeLayer(1);

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
                GameObject hhh = Instantiate(rock, transform.position + new Vector3(i,depth,j),Quaternion.identity); 
                hhh.GetComponent<RockController>().localPos = new Vector3(depth, i, j);
                map[(int)depth, i + 100, j + 100] = 1;
            }
        }
    }

    public void breakRock(float depth, int x, int y)
    {
        Debug.Log("hiii");
        try
        {
            map[(int)depth, x + 100, y + 100] = -1;
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
        if (depth >= 0 && map[depth, x + 100, y + 100] == -1)
        {
            Debug.Log("smth here");
            return;
        }
        try
        {
            map[depth, x + 100, y + 100] = 1;

            GameObject ff = Instantiate(rock, transform.position + new Vector3(x, -depth, y), Quaternion.identity);
            ff.GetComponent<RockController>().localPos = new Vector3(depth, x ,y);
        }
        catch
        {
            Debug.Log("nah");
        }
    }
}
