using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine; 

public class CameraController : MonoBehaviour
{
    public float sens; 
    private float xRotation;
    private float yRotation;
    public Transform cam;
    public bool firstPerson = true;
    public GameObject player;
    PlayerController playerController;
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        cam = transform.GetChild(0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        float mouseX = Input.GetAxisRaw("Mouse X") * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sens;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        if(playerController.movementState != 0) GetComponent<Attach>().other.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (firstPerson)
            {
                cam.Translate(0, 1, -5);
                firstPerson = false;
            }
            else
            {
                cam.Translate(0, -1, 5);
                firstPerson = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if(Physics.Raycast(ray,out RaycastHit hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Rock")
                {
                    hit.collider.GetComponent<RockController>();
                }
            }
        }
    }
}
