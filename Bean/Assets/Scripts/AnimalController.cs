using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float jumpCount = 10f;
    public float health = 100f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        jumpCount -= Time.deltaTime;

        if(jumpCount < 0)
        {
            rb.AddForce(new Vector3(Random.Range(7f, 20f), Random.Range(7f, 20f), Random.Range(7f, 20f)),ForceMode.Impulse);
            jumpCount = Random.Range(3f, 6f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health -= 25f;
        }
    }
}
