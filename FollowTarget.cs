using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow1Target : MonoBehaviour
{

    public Transform player1;//tank1的transform组件
    public Transform player2;//tank2的transform组件

    private Camera camera;//camera组件
    private Vector3 offset;//tank中心和camera的偏移量

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - (player1.position + player2.position) / 2;
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null || player2 == null)
            return;
        transform.position = (player1.position + player2.position) / 2 + offset;
        float distance = Vector3.Distance(player1.position, player2.position);
        if (distance <= 10f)
            return;
        float size = distance * 0.875f;//计算size大小
        camera.orthographicSize = size;
    }
}
