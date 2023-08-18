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
    public int movementState = 1;
    public GameObject cam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {


        Vector3 vel = new Vector3();
        switch (movementState) {
            case 0:
                if (Input.GetKey(KeyCode.W)) vel.z = speed;
                if (Input.GetKey(KeyCode.S)) vel.z = -speed;
                if (Input.GetKey(KeyCode.A)) vel.x = -speed;
                if (Input.GetKey(KeyCode.D)) vel.x = speed;
                rb.freezeRotation = false;
                if (Input.GetKey(KeyCode.Space)) /*rb.AddForce(Vector3.Scale(vel, cam.transform.GetChild(0).forward)*/ rb.AddForce(cam.transform.GetChild(0).forward.normalized);
                break;
            case 1:
                if (Input.GetKey(KeyCode.W)) vel.z = speed;
                if (Input.GetKey(KeyCode.S)) vel.z = -speed;
                if (Input.GetKey(KeyCode.A)) vel.x = -speed;
                if (Input.GetKey(KeyCode.D)) vel.x = speed;
                if (Input.GetKey(KeyCode.Space) && grounded)
                {
                    rb.AddForce(new Vector3(0, jumpForce, 0));
                    grounded = false;
                }
                transform.Translate(vel * Time.deltaTime);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}
