using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell1 : MonoBehaviour
{
    float distance;
    int attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Tank");
        foreach (GameObject enemy in allEnemy)
        {
            distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            attack = 0;
            if (distance < 3)
            {
                attack = 10 - (int)distance * 3;
            }
            enemy.SendMessage("TakeDamage", attack);
        }
        GameObject[] allplayer = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in allplayer)
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);
            attack = 0;
            if (distance < 3)
            {
                attack = 10 - (int)distance * 3;
            }
            player.SendMessage("TakeDamage", attack);
        }
        //GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
        if (collider.tag == "Tank" || collider.tag == "Player")
        {
            int attack = Random.Range(20, 30);
            collider.SendMessage("TakeDamage", attack);
        }
    }
}
