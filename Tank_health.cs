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

    public GameObject gameOverPanel;

    private int hptotal;
    private static int enemy_score=0;
    [SerializeField] private Text enemy_score_text;

    // Start is called before the first frame update
    void Start()
    {
        hptotal = hp;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hp_recover()
    {
        if (hp <= 50)
        {
            hp = hp + 50;
        }
        if (hp > 50)
        { 
            hp = 100;
        }
        hpSlider.value = (float)hp / hptotal;
    }

    void TakeDamage()
    {
        if (hp <= 0)
        {
            return;
        }
        hp -= Random.Range(10, 20);
        hpSlider.value = (float)hp / hptotal;
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
            if (this.tag == "Tank")
            {
                enemy_score+=100;
                Debug.Log("SCORES:" + enemy_score);
                enemy_score_text.text = "SCORES:" + enemy_score;
            }
            gameOverPanel.SetActive(true);
        }
    }
}
