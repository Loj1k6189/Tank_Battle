using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontorl : MonoBehaviour
{
    public Transform player;
    private float mouseX, mouseY;
    public float mouseSensitivity;
    public float xrotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -30f, 30f);
        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
    }
}
