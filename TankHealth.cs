using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float health = 100.0f;   //血量
    public float armour = 0.0f;     //护甲
    public float armTough = 0.0f;   //盔甲韧性
    public GameObject tankExplosion;
    private float realDamage;     //真实伤害
    private float origDamage;     //原始伤害

    public AudioClip tankExplosionSound;
    //private Transform audioPlayer;
    //private AudioSource audioSource;

    public Slider healthBar;      //血条

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
        if (health <= 0)                     //承伤前就摧毁的坦克属于错误，直接退出
            return;
        origDamage = Random.Range(10, 20);   //击中后随机受伤10到20点
        if (origDamage <= 1.6f * armour + 0.2f * armour * armTough)     //根据盔甲值和盔甲韧性计算真实伤害
            realDamage = (1 / (6.25f * armTough + 50)) * origDamage * origDamage + (1 - armour / 25) * origDamage;
        else
            realDamage = (1 - armour / 125) * origDamage;

        health-= realDamage;                 //生命值减少
        healthBar.value = health;            //更新血条
        if (health <= 0)                     //如果承伤后才被摧毁
        {
            //audioSource.PlayOneShot(tankExplosionSound);
            AudioSource.PlayClipAtPoint(tankExplosionSound, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);    //在当前位置实例化坦克爆炸效果
            GameObject.Destroy(this.gameObject);
        } 
    }
}
