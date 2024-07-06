                                                                 //Tank攻击脚本//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_Attack : MonoBehaviour{

    //开放参数接口
    public GameObject shellPrefab;           //子弹预制体
    public KeyCode fireKey = KeyCode.Space;  //开火键
    public float shellSpeed = 10;            //Tank移动速度
    public AudioClip shotAudio;              //子弹发射音效
    public Slider ShellSlider;               //弹药条

    //私有变量
    private Transform firePoint;  //开火位置
    private int NumShell;         //当前子弹数量

    //初始化开火点、子弹数量、血条
    void Start(){
        firePoint = transform.Find("FirePoint");
        NumShell = 0;                            
        ShellSlider.value = 0;
    }

    //进行中，控制开火
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

    //接受生成子弹的碰撞信息，做出子弹数量增加回应
    void GetShell(){
        if (NumShell >= 3)
            return;
        NumShell++;
        ShellSlider.value = (float)NumShell / 2;
    }
}