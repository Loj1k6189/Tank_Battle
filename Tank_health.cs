using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tank_health : MonoBehaviour
{
    public int hp = 100;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;
    public Slider hpSlider;
    //public GameObject target;
    private int hptotal;
    // Start is called before the first frame update
    void Start()
    {
        hptotal = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SJ() {
        hp += 50;
        hpSlider.value = (float)hp / hptotal;
    }

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
}
