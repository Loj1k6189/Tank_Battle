                                                     //ǽѪ���ű�//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHp : MonoBehaviour{

    //���Ų����ӿ�
    public int Wallhp = 1;//Ѫ��

    //��Ӧ�ӵ���ײ��������Ϣ�������е�ǽ�ݻ�
    void WallDamage(){
        if (Wallhp <= 0)
            return;
        Wallhp --;
        if (Wallhp <= 0){
            GameObject.Destroy(this.gameObject);
        }
    }
}
