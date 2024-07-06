using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform player1;     //Tank1��Transform���
    public Transform player2;     //Tank2��Transform���

    private Camera camera;        //������
    private Vector3 offset;       //�����̹������λ�õ�ƫ����

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - (player1.position + player2.position) / 2;   //��ȡƫ����
        camera=this.GetComponent<Camera>();                                        //��ȡ��Ϸ�е�camera���
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null && player2 == null) return;                            //��Ϸ����ʱֹͣ����
        if (player1 == null)
        {
            transform.position = player2.position + offset;
            return;
        }
        if(player2 == null)
        {
            transform.position = player1.position + offset;
            return;
        }
        transform.position = (player1.position + player2.position) / 2 + offset;   //�������λ��
        float distance = Vector3.Distance(player1.position, player2.position);     //����̹�˾���
        if (distance <= 7f) return;                                                //������СֵΪ7
        float size = distance * 1.0f;                                              //���������Ұ����
        camera.orthographicSize = size;                                            //������õ�������ֵ�������
    }
}
