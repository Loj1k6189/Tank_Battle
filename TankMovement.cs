using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 5;         //̹���ƶ��ٶ�
    public float angularSpeed = 2;  //̹����ת�ٶ�
    public float number = 1;        //��ұ��

    private Rigidbody rigidbody;    //�������

    public AudioClip engineIdle;    //���������Ƶ
    public AudioClip engineDriving; //������ʻ��Ƶ

    private AudioSource audio;       //��Ƶ���

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();   //��ø������
        audio = this.GetComponent<AudioSource>();     //�����Ƶ���
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("VerticalP" + number);          //��ȡ���¼�ͷ��������Ϣ
        rigidbody.velocity = transform.forward * v * speed;            //���ø���ʩ���ٶ�

        float h = Input.GetAxis("HorizontalP" + number);        //��ȡ���Ҽ�ͷ��������Ϣ
        rigidbody.angularVelocity = transform.up * h * angularSpeed;   //���ø���ʩ����ת�ٶ�

        if (v != 0 || h != 0)                         //̹���ƶ�ʱ������ʻ��Ƶ
        {
            audio.clip = engineDriving;
            if (!audio.isPlaying)
                audio.Play();
        }
        if (v == 0 && h == 0)                         //̹��ֹͣʱ���ſ�����Ƶ
        {
            audio.clip = engineIdle;
            if (!audio.isPlaying)
                audio.Play();
        }
    }
}
