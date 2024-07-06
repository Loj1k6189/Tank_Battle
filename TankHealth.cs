using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float health = 100.0f;   //Ѫ��
    public float armour = 0.0f;     //����
    public float armTough = 0.0f;   //��������
    public GameObject tankExplosion;
    private float realDamage;     //��ʵ�˺�
    private float origDamage;     //ԭʼ�˺�

    public AudioClip tankExplosionSound;
    //private Transform audioPlayer;
    //private AudioSource audioSource;

    public Slider healthBar;      //Ѫ��

    // Start is called before the first frame update
    void Start()
    {
        //audioPlayer = transform.Find("TankAudioPlayer");
        //audioSource = audioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()
    { 
        if (health <= 0)                     //����ǰ�ʹݻٵ�̹�����ڴ���ֱ���˳�
            return;
        origDamage = Random.Range(10, 20);   //���к��������10��20��
        if (origDamage <= 1.6f * armour + 0.2f * armour * armTough)     //���ݿ���ֵ�Ϳ������Լ�����ʵ�˺�
            realDamage = (1 / (6.25f * armTough + 50)) * origDamage * origDamage + (1 - armour / 25) * origDamage;
        else
            realDamage = (1 - armour / 125) * origDamage;

        health-= realDamage;                 //����ֵ����
        healthBar.value = health;            //����Ѫ��
        if (health <= 0)                     //������˺�ű��ݻ�
        {
            //audioSource.PlayOneShot(tankExplosionSound);
            AudioSource.PlayClipAtPoint(tankExplosionSound, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);    //�ڵ�ǰλ��ʵ����̹�˱�ըЧ��
            GameObject.Destroy(this.gameObject);
        } 
    }
}
