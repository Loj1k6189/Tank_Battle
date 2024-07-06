using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontorl : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float number = 1;
    private Vector3 dir;

    public GameObject Jr;
    // Start is called before the first frame update
    void Start()
    {
        //Jr.SendMessage("hideui");
    }

    // Update is called once per frame
    void Update()
    {
        //float v = Input.GetAxis("Verticalp" + number);
        //float h = Input.GetAxis("Horizontalp" + number);
        //dir = transform.forward * v * speed + transform.right * h * speed;
        //cc.Move(dir * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {
            Jr.SendMessage("jump");
            GameObject.Destroy(this.gameObject);
        }
    }
}
