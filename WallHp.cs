                                                     //墙血量脚本//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHp : MonoBehaviour{

    //开放参数接口
    public int Wallhp = 1;//血量

    //响应子弹碰撞发出的信息，将击中的墙摧毁
    void WallDamage(){
        if (Wallhp <= 0)
            return;
        Wallhp --;
        if (Wallhp <= 0){
            GameObject.Destroy(this.gameObject);
        }
    }
}
