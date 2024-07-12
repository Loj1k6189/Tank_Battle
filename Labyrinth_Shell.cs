                                                          //子弹预制体脚本//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth_Shell : MonoBehaviour{

    //开放参数接口
    public GameObject shellExplosionPrefab;
    public AudioClip shellExplosionAudio;
    //子弹与Tank和强碰撞时，发送特定信息

    public void OnTriggerEnter(Collider collider){
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);                      //播放子弹爆炸音乐
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);      //实例化爆炸效果
        GameObject.Destroy(this.gameObject);                                                       //删除子弹

        //碰撞到Tank时发送TankDamage
        if (collider.tag == "Tank1" || collider.tag == "Tank2"){
            collider.SendMessage("TankDamage");//碰撞到tank时发送消息
        }
        //碰撞到强时发送WallDamage

        if (collider.tag == "Wall"){
            GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);//实例化爆炸效果
            collider.SendMessage("WallDamage");//碰撞到tank时发送消息
            GameObject.Destroy(this.gameObject);//删除子弹
        }
    }
}
