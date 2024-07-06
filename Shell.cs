using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    public GameObject shellExplosionPrefab;
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
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);//实例化爆炸效果
        GameObject.Destroy(this.gameObject);//删除子弹
        if (collider.tag == "Tank1" || collider.tag == "Tank2")
        {
            collider.SendMessage("TankDamage");//碰撞到tank时发送消息
        }
    }

}
