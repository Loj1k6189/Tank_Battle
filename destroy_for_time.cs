using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_for_time : MonoBehaviour
{
    public float time = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, time);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
