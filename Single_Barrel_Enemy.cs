using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Single_Barrel_Enemy : MonoBehaviour
{
    public int hp = 200;
    public GameObject barrelExplosion;
    public AudioClip barrelExplosionAudio;
    public Slider hpSlider;
    public GameObject gameOverPanel;

    private int hptotal;
    // Start is called before the first frame update
    void Start()
    {
        hptotal = hp;
        gameOverPanel.SetActive(false);
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
            AudioSource.PlayClipAtPoint(barrelExplosionAudio, transform.position);
            GameObject.Instantiate(barrelExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);

            gameOverPanel.SetActive(true);

        }
    }



    void OnDestroy()
    {
        S_Barrel_Enemy_Manager.barrelDestroyed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
