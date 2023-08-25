using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float jumpCount = 10f;
    public float health = 100f;
    Rigidbody rb;
    public GameObject player;
    public ParticleSystem hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        jumpCount -= Time.deltaTime;

        if(jumpCount < 0)
        {
            rb.AddForce(new Vector3(Random.Range(7f, 10f), Random.Range(7f, 10f), Random.Range(7f, 10f)),ForceMode.Impulse);
            jumpCount = Random.Range(3f, 6f);
        }

        if(health <= 0)
        {
            player.GetComponent<PlayerInv>().backPack["Beef Beans"][0] += 1;
            health = 100000;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(hit, collision.transform.position, Quaternion.identity);
            health -= 20f;
        }
    }
}
