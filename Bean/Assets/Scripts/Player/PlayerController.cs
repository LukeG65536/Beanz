using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rollSpeed;
    public float dashForce;
    public float maxSpeed;
    public float gravityPull;
    bool grounded = true;
    public Rigidbody rb;
    public int movementState = 1;
    public GameObject cam;
    float dashCooldown = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {


        Vector3 vel = new Vector3();
        switch (movementState) {
            case 0:
                rb.freezeRotation = false;
                Vector3 dir = cam.transform.GetChild(0).forward.normalized * rollSpeed / (rb.velocity.magnitude + 10f);
                dir.y = 0;
                if (Input.GetKey(KeyCode.Space)) /*rb.AddForce(Vector3.Scale(vel, cam.transform.GetChild(0).forward)*/ rb.AddForce(dir);
                if (dashCooldown >= 0)
                {
                    dashCooldown -= Time.deltaTime;
                }
                else
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        rb.velocity = new Vector3(0, rb.velocity.y, 0);
                        rb.AddForce(cam.transform.GetChild(0).forward.normalized * dashForce, ForceMode.Impulse);
                        dashCooldown = 3;
                    }
                }
                break;
            case 1:
                if (Input.GetKey(KeyCode.W)) vel.z = speed;
                if (Input.GetKey(KeyCode.S)) vel.z = -speed;
                if (Input.GetKey(KeyCode.A)) vel.x = -speed;
                if (Input.GetKey(KeyCode.D)) vel.x = speed;
                if (Input.GetKey(KeyCode.Space) && grounded)
                {
                    grounded = false;
                }
                transform.Translate(vel * Time.deltaTime);
                break;
        }
    }
}
