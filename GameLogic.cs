using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject WinResult;
    public GameObject LoseResult;
    public GameObject player;
    public GameObject enemy_barrel;
    public static bool player_destroy = false;
    public void judgement()
    {
        if (Barrel_Enemy_Manager.barrelDestroyed)
        {
            Barrel_Enemy_Manager.barrelDestroyed = false;
            LoseResult.SetActive(true);
        }
        else if (player_destroy)
        {
            player_destroy = false;
            WinResult.SetActive(true);
        }
    }
}
