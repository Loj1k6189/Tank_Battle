                                                         //����ͷ�Զ�����ű�//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour{

    //���Ų����ӿ�
    public Transform player1;//tank1��transform���
    public Transform player2;//tank2��transform���

    //˽�б���
    private Camera camera;//camera���
    private Vector3 offset;//tank���ĺ�camera��ƫ����

    // ��ʼ�����룬�������ͷ���
    void Start()
    {
        offset = transform.position - (player1.position + player2.position) / 2;
        camera = this.GetComponent<Camera>();
    }

    //�����У���������ͷλ��
    void Update()
    {
        if (player1 == null || player2 == null)
            return;
        transform.position = (player1.position + player2.position) / 2 + offset;
        float distance = Vector3.Distance(player1.position, player2.position);
        if (distance <= 10f)
            return;
        float size = distance * 0.875f;//����size��С
        camera.orthographicSize = size;
    }
}
