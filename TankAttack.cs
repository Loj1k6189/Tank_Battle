using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    public GameObject shellPrefab;            //创建子弹对象
    public KeyCode fireKey = KeyCode.Space;   //修改发射按键为空格键
    public float shellSpeed = 10;             //子弹初速度

    public AudioClip shotSound;               //子弹发射音效

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");   //找到发射点
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(fireKey))        //开火键按下
        {
            AudioSource.PlayClipAtPoint(shotSound, firePoint.position);                                                //播放子弹发射音效
            GameObject go = GameObject.Instantiate(shellPrefab, firePoint.position, firePoint.rotation) as GameObject; //在发射点实例化子弹
            go.GetComponent<Rigidbody>().velocity = go.transform.forward*shellSpeed;                                   //获得子弹刚体组件设置速度
        }
    }
}
