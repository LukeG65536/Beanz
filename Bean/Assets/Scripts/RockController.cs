using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public float breakTime = 2;
    public string type = "Rock Bean";
    public void hit(PlayerInv inv)
    {
        inv.backPack[type][0] += 1;
        breakRock();//hi
    }

    IEnumerator breakRock()
    {
        yield return new WaitForSeconds(breakTime);
        Destroy(gameObject);
    }
}
