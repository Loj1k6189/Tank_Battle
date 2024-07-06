using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Guard : MonoBehaviour
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
            collider.SendMessage("guard");
            GameObject.Destroy(this.gameObject);
        }
    }
}
