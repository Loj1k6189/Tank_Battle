using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tank_health : MonoBehaviour
{
    public int hp = 100;
    public GameObject tankExplosion;
    public GameObject tankExplosion1;
    public GameObject tankExplosioned;
    public GameObject tankExplosioning;
    public AudioClip tankExplosionAudio;
    public Slider hpSlider;
    public GameObject over;
    //public GameObject target;
    private int hptotal;
    public GameObject tankscore;
    public int scores = 100;
    public float hftime1 = 2f;
    // Start is called before the first frame update
    void Start()
    {
        hptotal = hp;
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("selfHF1", hftime1, hftime1);
    }
    void SJ(int hf) {
        hp += hf;
        if (hp > hptotal)
            hp = hptotal;
        hpSlider.value = (float)hp / hptotal;
    }
    /*
    void TakeDamage()
    {
        if (hp <= 0)
            return;
        hp -= Random.Range(10, 20);
        hpSlider.value = (float)hp / hptotal;
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            //target.SendMessage("showui");
            GameObject.Destroy(this.gameObject);
        }
    }
    */
    void TakeDamage(int attack)
    {
        //if (hp <= 0)
            //return;
        hp -= attack;
        //GameObject.Instantiate(tankExplosioning, transform.position + Vector3.up, transform.rotation);
        hpSlider.value = (float)hp / hptotal;
        if (hp <= 0)
        {
            tankscore.SendMessage("scoreup", scores);
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            //int a=Random.Range(9, 11);
            //if (a ==10)
            //{
                //GameObject.Instantiate(tankExplosion1, transform.position + Vector3.up, transform.rotation);
            //}
            GameObject.Destroy(this.gameObject);
            GameObject.Instantiate(tankExplosioned, transform.position, transform.rotation);
            over.SendMessage("ActivateObject");
        }
    }
    void healthup()
    {
        hptotal += 100;
        hpSlider.value = (float)hp / hptotal;
    }
    void ememyup()
    {
        hptotal += 50;
        hp += 25;
        hpSlider.value = (float)hp / hptotal;
    }
    void selfHF()
    {
        if (hp< hptotal)
            hp+= 1;
        hpSlider.value = (float)hp / hptotal;
    }
}
