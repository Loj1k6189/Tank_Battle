using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_health : MonoBehaviour
{

    public int hp = 100;//血量
    public GameObject tankExplosion;
    public GameObject collideExplosionPrefab;
    public AudioClip tankExplosionAudio;

    public Slider hpSlider;

    private int hpTotal;

    // Start is called before the first frame update
    void Start()
    {
        hpTotal = hp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TankDamage()
    {
        if (hp <= 0)
            return;
        hp -= Random.Range(10, 20);
        hpSlider.value = (float)hp / hpTotal;
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }

    void TankCollide()
    {
        if (hp <= 0)
            return;
        GameObject.Instantiate(collideExplosionPrefab, transform.position, transform.rotation);//实例化爆炸效果
        hp -= Random.Range(5, 8);
        hpSlider.value = (float)hp / hpTotal;
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}