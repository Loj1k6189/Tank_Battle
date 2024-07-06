using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    public KeyCode selectKey = KeyCode.Space;
    public GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(selectKey))
        {
            targetObject.SetActive(true);
        }
    }
    public void ActivateObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);  
        }
    }

    
    public void DeactivateObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
