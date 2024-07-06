using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{

    public float speed = 5;  //坦克移动速度
    public float angularSpeed = 2;  //坦克旋转速度
    public float number = 1;
    public AudioClip idleAudio;
    public AudioClip drivingAudio;

    private AudioSource audio;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();  //获得刚体组件
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("VerticalP" + number);  //按下上、下箭头触发
        rigidbody.velocity = transform.forward * v * speed;  //利用刚体施加速度

        float h = Input.GetAxis("HorizontalP" + number);  //按下左、右箭头触发
        rigidbody.angularVelocity = transform.up * h * angularSpeed;  //利用刚体施加旋转速度

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