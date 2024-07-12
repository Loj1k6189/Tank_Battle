using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Labyrinth_Jump_End : MonoBehaviour
{

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Tank1" || collider.tag == "Tank2")
        {
            GameObject.Find("GradeBoard").SendMessage("TakeGrade");
            SceneManager.LoadScene(2);
        }
    }
}
