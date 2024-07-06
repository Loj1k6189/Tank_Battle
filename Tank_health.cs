                                                            //Tank�����ű�//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_health : MonoBehaviour{

    //���Ų����ӿ�
    public int hp = 100;                  //Ѫ��
    public GameObject tankExplosion;      //��ըЧ��
    public AudioClip tankExplosionAudio;  //��ը����
    public Slider hpSlider;               //����Ѫ��

    //˽�б���
    private int hpTotal;

    //��ʼ��Ѫ����
    void Start(){
        hpTotal = hp;
    }

    //�����ӵ���ײ��Ϣ���۳�Ѫ��
    void TankDamage(){
        if (hp <= 0)
            return;
        hp -= Random.Range(10, 20);
        hpSlider.value = (float)hp / hpTotal;
        if (hp <= 0){
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}