using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public GameObject tank1;
    public GameObject tank2;
    public int enemy_score = 0;
    public int jieduan = 10000;
    //public GameObject Flowchart1;
    [SerializeField] private Text enemy_score_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreup(0);
        if (enemy_score > jieduan)
        {
            tank1.SendMessage("ememyup");
            tank2.SendMessage("ememyup");
            jieduan = jieduan * 2;
        }
    }
    public void scoreup(int scores)
    {
        enemy_score += scores;
        Debug.Log("SCORES:" + enemy_score);
        enemy_score_text.text = "SCORES:" + enemy_score;
        //GameObject.Flowchart1.GetComponent<Flowchart>().money += 1;
    }
}
