                                                             //生成刷新子弹脚本//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour{

    //开放参数接口
    public Transform[] itpoints;
    public float ittime = 10f;
    public GameObject items;
    public int k;

    //初始化生成数量并在位置0生成子弹
    void Start(){
        InvokeRepeating("Creatitem", ittime, ittime);
        k = 0;
        Instantiate(items, itpoints[0].position, itpoints[0].rotation);
    }

    //接受CreatShell信息，并将已经生成的子弹数量-1
    void CreateShell(){
        k--;
    }

    //响应Createitem信息刷新子弹
    void Creatitem(){
        if (k >= 4)
            return;
        k++;
        int itindex = UnityEngine.Random.Range(1, itpoints.Length);
        Instantiate(items, itpoints[itindex].position, itpoints[itindex].rotation);
    }
}
