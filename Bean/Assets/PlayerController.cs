using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravityPull;
    bool grounded = true;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 vel = new Vector3();
        if (Input.GetKey(KeyCode.W)) vel.z = speed;
        if (Input.GetKey(KeyCode.S)) vel.z = -speed;
        if (Input.GetKey(KeyCode.A)) vel.x = -speed;
        if (Input.GetKey(KeyCode.D)) vel.x = speed;
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector3(0, jumpForce , 0));
            grounded = false;
        }
        transform.Translate(vel * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}
