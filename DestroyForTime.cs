                                                           //�ӵ���ըЧ�����ٽű�//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForTime : MonoBehaviour
{

    //���Ų����ӿ�
    public float time = 1.5f;

    //��ʼ����1.5s�����ٱ�ըЧ��
    void Start(){
        Destroy(this.gameObject, time);
    }

}
