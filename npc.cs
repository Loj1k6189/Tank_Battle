using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcEntity : MonoBehaviour
{
    [Header("npc名字，需与Block名字一致")]
    public string npcName;
    public GameObject bo;
    private Flowchart flowchart;
    private bool canSay;
    public KeyCode Key1 = KeyCode.F;

    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }
    private void Update()
    {
        //鼠标按下左键触发对话方法
        //if (Input.GetMouseButtonDown(0))
        //{
            //Say();
        //}
        if (Input.GetKeyDown(Key1))
        {
            Say();
        }

    }
    void Say()
    {
        if (canSay)
        {
            if (flowchart.HasBlock(npcName))
            {
                flowchart.ExecuteBlock(npcName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //如果检测到玩家进入触发范围
        if (other.tag.Equals("Player"))
        {
            canSay = true;
            bo.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //如果检测到玩家离开触发范围
        if (other.tag.Equals("Player"))
        {
            canSay = false;
            bo.SetActive(false);
        }
    }
}