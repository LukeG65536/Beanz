using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public float breakTime = 2;
    public string type = "Rock Beans";
    public Material[] gems;
    public Material rock;

    public void Start()
    {
        if (Random.Range(0, 2) == 1)
        {
            GetComponent<MeshRenderer>().material = gems[Random.Range(0, gems.Length)];
        }
        else 
        {
            GetComponent<MeshRenderer>().material = rock;
        }
    }
    public void hit(PlayerInv inv)
    {
        inv.backPack[type][0] += 1;
        StartCoroutine(breakRock());
        Debug.Log("hi");
    }

    IEnumerator breakRock()
    {
        yield return new WaitForSeconds(breakTime);
        Destroy(gameObject);
    }
}
