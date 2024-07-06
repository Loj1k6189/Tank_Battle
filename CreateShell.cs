                                                       //环境生成子弹预制体脚本//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShell : MonoBehaviour{

    //开放参数接口
    public GameObject shellExplosionPrefab;

    //生成的子弹与Tank碰撞时向Tank发送GetShell信息，向生成位置组件发送CreatShell信息
    public void OnTriggerEnter(Collider collider){
        if (collider.tag == "Tank1" || collider.tag == "Tank2"){
            collider.SendMessage("GetShell");                          //碰撞到tank时发送消息
            GameObject.Find("ItPoint").SendMessage("CreateShell");     //碰撞到tank时发送消息
            GameObject.Destroy(this.gameObject);                       //删除子弹
        }
    }
}
