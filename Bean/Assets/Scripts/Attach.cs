using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    public GameObject other;
    public Vector3 pos;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = other.transform.position + pos;
    }
}
