using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    public GameObject shellPrefab;            //�����ӵ�����
    public KeyCode fireKey = KeyCode.Space;   //�޸ķ��䰴��Ϊ�ո��
    public float shellSpeed = 10;             //�ӵ����ٶ�

    public AudioClip shotSound;               //�ӵ�������Ч

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");   //�ҵ������
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(fireKey))        //���������
        {
            AudioSource.PlayClipAtPoint(shotSound, firePoint.position);                                                //�����ӵ�������Ч
            GameObject go = GameObject.Instantiate(shellPrefab, firePoint.position, firePoint.rotation) as GameObject; //�ڷ����ʵ�����ӵ�
            go.GetComponent<Rigidbody>().velocity = go.transform.forward*shellSpeed;                                   //����ӵ�������������ٶ�
        }
    }
}
