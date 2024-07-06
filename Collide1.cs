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
        GameObject.Destroy(this.gameObject);//ɾ���ӵ�
        if (collider.tag == "Tank2")
        {
            collider.SendMessage("TankCollide");//��ײ��tankʱ������Ϣ
        }
    }

}