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
    private void Start()
    {
        cam = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
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
        GetComponent<Attach>().other.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (firstPerson)
            {
                cam.Translate(0, 0, -3);
                firstPerson = false;
            }
            else
            {
                cam.Translate(0, 0, 3);
                firstPerson = true;
            }
        }
    }
}
