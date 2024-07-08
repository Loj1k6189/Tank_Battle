using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public GameObject shellExplosionPrehab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject.Instantiate(shellExplosionPrehab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
        if(collider.tag == "Tank")
        {
            collider.SendMessage("TakeDamage");
        }
    }
}
