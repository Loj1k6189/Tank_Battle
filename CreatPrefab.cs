                                                             //����ˢ���ӵ��ű�//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour{

    //���Ų����ӿ�
    public Transform[] itpoints;
    public float ittime = 10f;
    public GameObject items;
    public int k;

    //��ʼ��������������λ��0�����ӵ�
    void Start(){
        InvokeRepeating("Creatitem", ittime, ittime);
        k = 0;
        Instantiate(items, itpoints[0].position, itpoints[0].rotation);
    }

    //����CreatShell��Ϣ�������Ѿ����ɵ��ӵ�����-1
    void CreateShell(){
        k--;
    }

    //��ӦCreateitem��Ϣˢ���ӵ�
    void Creatitem(){
        if (k >= 4)
            return;
        k++;
        int itindex = UnityEngine.Random.Range(1, itpoints.Length);
        Instantiate(items, itpoints[itindex].position, itpoints[itindex].rotation);
    }
}
