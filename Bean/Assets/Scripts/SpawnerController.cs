using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject animal;
    void Start()
    {
        StartCoroutine(spawn(2));
    }

    IEnumerator spawn(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(animal, transform.position, Quaternion.identity);
        Debug.Log("Animal Spawned");
        StartCoroutine(spawn(Random.Range(20, 40)));
    }
}
