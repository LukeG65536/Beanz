using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AnimalController : MonoBehaviour
{
    public float jumpCount = 10f;
    public float health = 100f;
    Rigidbody rb;
    public GameObject player;
    public ParticleSystem hit;
    public GameObject blood;
    VisualEffect bloodEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        blood =  Instantiate(blood, new Vector3(), Quaternion.identity);
        bloodEffect = blood.transform.GetChild(0).GetComponent<VisualEffect>();
    }
    void Update()
    {
        jumpCount -= Time.deltaTime;

        if(jumpCount < 0)
        {
            rb.AddForce(new Vector3(Random.Range(5f, 7f), Random.Range(5f, 7f), Random.Range(5f, 7f)),ForceMode.Impulse);
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
            blood.transform.position = collision.contacts[0].point;
            bloodEffect.Play();
            hit.Play();
            health -= 20f;
        }
    }
}
