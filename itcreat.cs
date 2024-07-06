using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itcreat : MonoBehaviour
{
    public Transform[] itpoints;
    public float ittime=10f;
    public GameObject items;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("creatitem", ittime, ittime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void creatitem()
    {
        int itindex = Random.Range(0, itpoints.Length);
        Instantiate(items, itpoints[itindex].position, itpoints[itindex].rotation);
    }
}
