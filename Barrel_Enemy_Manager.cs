using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrel_Enemy_Manager : MonoBehaviour
{
    public GameObject successUI;
    public static bool barrelDestroyed = false;
    public GameObject enemyDestory;
    void Update()
    {
        if (Barrel_Enemy_Manager.barrelDestroyed)
        {
            Barrel_Enemy_Manager.barrelDestroyed = false;

            GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Tank");
            foreach (GameObject enemy in allEnemy)
            {
                Instantiate(enemyDestory, enemy.transform.position, Quaternion.identity);
                Destroy(enemy);
            }

            if (successUI != null)
            {
                successUI.SetActive(true); 
            }

        }
    }
}
