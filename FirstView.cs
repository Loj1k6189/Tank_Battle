                                                    //��һ�˳�����ͷ�ű�//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstView : MonoBehaviour
{
    //���Ų����ӿ�
    public Transform Player;
    public float mouseSensitivity;
    public float xRototation;

    //˽�б���
    private float mouseX, mouseY;

    //�����У�����Tankλ�ú�����ƶ���������ͷλ����Ƕ�
    private void Update(){
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRototation -= mouseY;
        xRototation = Mathf.Clamp(xRototation, -70, 70);

        Player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRototation, 0, 0);

    }

}
