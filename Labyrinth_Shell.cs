                                                          //�ӵ�Ԥ����ű�//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth_Shell : MonoBehaviour{

    //���Ų����ӿ�
    public GameObject shellExplosionPrefab;
    public AudioClip shellExplosionAudio;
    //�ӵ���Tank��ǿ��ײʱ�������ض���Ϣ

    public void OnTriggerEnter(Collider collider){
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);                      //�����ӵ���ը����
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);      //ʵ������ըЧ��
        GameObject.Destroy(this.gameObject);                                                       //ɾ���ӵ�

        //��ײ��Tankʱ����TankDamage
        if (collider.tag == "Tank1" || collider.tag == "Tank2"){
            collider.SendMessage("TankDamage");//��ײ��tankʱ������Ϣ
        }
        //��ײ��ǿʱ����WallDamage

        if (collider.tag == "Wall"){
            GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);//ʵ������ըЧ��
            collider.SendMessage("WallDamage");//��ײ��tankʱ������Ϣ
            GameObject.Destroy(this.gameObject);//ɾ���ӵ�
        }
    }
}
