using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcEntity : MonoBehaviour
{
    [Header("npc���֣�����Block����һ��")]
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
        //��갴����������Ի�����
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
        //�����⵽��ҽ��봥����Χ
        if (other.tag.Equals("Player"))
        {
            canSay = true;
            bo.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //�����⵽����뿪������Χ
        if (other.tag.Equals("Player"))
        {
            canSay = false;
            bo.SetActive(false);
        }
    }
}