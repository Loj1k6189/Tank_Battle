                                                    //第一人称摄像头脚本//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstView : MonoBehaviour
{
    //开放参数接口
    public Transform Player;
    public float mouseSensitivity;
    public float xRototation;

    //私有变量
    private float mouseX, mouseY;

    //进行中，根据Tank位置和鼠标移动调整摄像头位置与角度
    private void Update(){
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRototation -= mouseY;
        xRototation = Mathf.Clamp(xRototation, -70, 70);

        Player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRototation, 0, 0);

    }

}
