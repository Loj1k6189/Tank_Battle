using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_SpeedUp : MonoBehaviour
{
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


        if (collider.tag == "Player")
        {
            collider.SendMessage("Speed_Up");
            GameObject.Destroy(this.gameObject);
        }
    }
}
