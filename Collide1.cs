using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide1 : MonoBehaviour
{
    public AudioClip shellExplosionAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);
        GameObject.Destroy(this.gameObject);//删除子弹
        if (collider.tag == "Tank2")
        {
            collider.SendMessage("TankCollide");//碰撞到tank时发送消息
        }
    }

}