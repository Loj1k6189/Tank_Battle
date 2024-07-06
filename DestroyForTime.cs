                                                           //子弹爆炸效果销毁脚本//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForTime : MonoBehaviour
{

    //开放参数接口
    public float time = 1.5f;

    //初始化，1.5s后销毁爆炸效果
    void Start(){
        Destroy(this.gameObject, time);
    }

}
