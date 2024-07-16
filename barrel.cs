using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    public int hp = 100;
    float distance;
    int attack;
    public GameObject shellExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int attack)
    {
        if (hp <= 0)
            return;
        hp -= attack;
        if (hp <= 0)
        {
            bz();
        }
    }

    void bz()
    {
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Tank"); 
        foreach (GameObject enemy in allEnemy)
        {
            distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            attack = 0;
            if (distance <10) {
                attack = 50 - (int)distance *4;
            }
            enemy.SendMessage("TakeDamage",attack);
        }
        GameObject[] allplayer = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in allplayer)
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);
            attack = 0;
            if (distance < 7)
            {
                attack = 50 - (int)distance * 7;
            }
            player.SendMessage("TakeDamage",attack); 
        }
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
    }
}
