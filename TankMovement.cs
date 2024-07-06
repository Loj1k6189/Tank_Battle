using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 5;         //坦克移动速度
    public float angularSpeed = 2;  //坦克旋转速度
    public float number = 1;        //玩家编号

    private Rigidbody rigidbody;    //刚体组件

    public AudioClip engineIdle;    //引擎空闲音频
    public AudioClip engineDriving; //引擎行驶音频

    private AudioSource audio;       //音频组件

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();   //获得刚体组件
        audio = this.GetComponent<AudioSource>();     //获得音频组件
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("VerticalP" + number);          //获取上下箭头按键的信息
        rigidbody.velocity = transform.forward * v * speed;            //利用刚体施加速度

        float h = Input.GetAxis("HorizontalP" + number);        //获取左右箭头按键的信息
        rigidbody.angularVelocity = transform.up * h * angularSpeed;   //利用刚体施加旋转速度

        if (v != 0 || h != 0)                         //坦克移动时播放行驶音频
        {
            audio.clip = engineDriving;
            if (!audio.isPlaying)
                audio.Play();
        }
        if (v == 0 && h == 0)                         //坦克停止时播放空闲音频
        {
            audio.clip = engineIdle;
            if (!audio.isPlaying)
                audio.Play();
        }
    }
}
