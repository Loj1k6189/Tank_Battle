using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_movement : MonoBehaviour
{
    public int life = 100;
    public int score = 10;
    public int damage = 10;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = life;
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = life;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = player.transform.position - gameObject.transform.position;
        gameObject.transform.position += v3.normalized * 1.0f * Time.deltaTime;
    }
}
