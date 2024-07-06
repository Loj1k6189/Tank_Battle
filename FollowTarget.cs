using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform player1;     //Tank1的Transform组件
    public Transform player2;     //Tank2的Transform组件

    private Camera camera;        //相机组件
    private Vector3 offset;       //相机和坦克中心位置的偏移量

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - (player1.position + player2.position) / 2;   //获取偏移量
        camera=this.GetComponent<Camera>();                                        //获取游戏中的camera组件
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null && player2 == null) return;                            //游戏结束时停止缩放
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
        transform.position = (player1.position + player2.position) / 2 + offset;   //调整相机位置
        float distance = Vector3.Distance(player1.position, player2.position);     //计算坦克距离
        if (distance <= 7f) return;                                                //设置最小值为7
        float size = distance * 1.0f;                                              //计算相机视野缩放
        camera.orthographicSize = size;                                            //将计算得到的缩放值赋给相机
    }
}
