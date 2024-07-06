                                                            //Tank生命脚本//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_health : MonoBehaviour{

    //开放参数接口
    public int hp = 100;                  //血量
    public GameObject tankExplosion;      //爆炸效果
    public AudioClip tankExplosionAudio;  //爆炸音乐
    public Slider hpSlider;               //生命血条

    //私有变量
    private int hpTotal;

    //初始化血条量
    void Start(){
        hpTotal = hp;
    }

    //接收子弹碰撞信息，扣除血量
    void TankDamage(){
        if (hp <= 0)
            return;
        hp -= Random.Range(10, 20);
        hpSlider.value = (float)hp / hpTotal;
        if (hp <= 0){
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}