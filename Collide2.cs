using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide2 : MonoBehaviour
{
    public AudioClip shellExplosionAudio1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter1(Collider collider1)
    {
        AudioSource.PlayClipAtPoint(shellExplosionAudio1, transform.position);
        GameObject.Destroy(this.gameObject);//ɾ���ӵ�
        if (collider1.tag == "Tank1")
        {
            collider1.SendMessage("TankCollide");//��ײ��tankʱ������Ϣ
        }
    }

}