                                                                 //Tank�����ű�//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_Attack : MonoBehaviour{

    //���Ų����ӿ�
    public GameObject shellPrefab;           //�ӵ�Ԥ����
    public KeyCode fireKey = KeyCode.Space;  //�����
    public float shellSpeed = 10;            //Tank�ƶ��ٶ�
    public AudioClip shotAudio;              //�ӵ�������Ч
    public Slider ShellSlider;               //��ҩ��

    //˽�б���
    private Transform firePoint;  //����λ��
    private int NumShell;         //��ǰ�ӵ�����

    //��ʼ������㡢�ӵ�������Ѫ��
    void Start(){
        firePoint = transform.Find("FirePoint");
        NumShell = 0;                            
        ShellSlider.value = 0;
    }

    //�����У����ƿ���
    void Update(){
        if (NumShell <= 0)
            return;
        if (Input.GetKeyDown(fireKey)){
            NumShell--;
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
            GameObject go = GameObject.Instantiate(shellPrefab, firePoint.position, firePoint.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
            ShellSlider.value = (float)NumShell / 2;
        }
    }

    //���������ӵ�����ײ��Ϣ�������ӵ��������ӻ�Ӧ
    void GetShell(){
        if (NumShell >= 3)
            return;
        NumShell++;
        ShellSlider.value = (float)NumShell / 2;
    }
}