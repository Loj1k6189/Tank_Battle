using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bff : MonoBehaviour
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
            collider.SendMessage("hp_recover");
            GameObject.Destroy(this.gameObject);
        }
    }

}
