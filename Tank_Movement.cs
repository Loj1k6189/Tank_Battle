using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{

    public float speed = 5;  //̹���ƶ��ٶ�
    public float angularSpeed = 2;  //̹����ת�ٶ�
    public float number = 1;
    public AudioClip idleAudio;
    public AudioClip drivingAudio;

    private AudioSource audio;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();  //��ø������
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("VerticalP" + number);  //�����ϡ��¼�ͷ����
        rigidbody.velocity = transform.forward * v * speed;  //���ø���ʩ���ٶ�

        float h = Input.GetAxis("HorizontalP" + number);  //�������Ҽ�ͷ����
        rigidbody.angularVelocity = transform.up * h * angularSpeed;  //���ø���ʩ����ת�ٶ�

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            audio.clip = drivingAudio;
            if (audio.isPlaying == false)
            {
                audio.Play();
            }
        }
        else
        {
            audio.clip = idleAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }
    }
}