                                                       //���������ӵ�Ԥ����ű�//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShell : MonoBehaviour{

    //���Ų����ӿ�
    public GameObject shellExplosionPrefab;

    //���ɵ��ӵ���Tank��ײʱ��Tank����GetShell��Ϣ��������λ���������CreatShell��Ϣ
    public void OnTriggerEnter(Collider collider){
        if (collider.tag == "Tank1" || collider.tag == "Tank2"){
            collider.SendMessage("GetShell");                          //��ײ��tankʱ������Ϣ
            GameObject.Find("ItPoint").SendMessage("CreateShell");     //��ײ��tankʱ������Ϣ
            GameObject.Destroy(this.gameObject);                       //ɾ���ӵ�
        }
    }
}
