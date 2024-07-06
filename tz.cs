using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JUMP : MonoBehaviour
{
    public int number=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void jump()
    {
        SceneManager.LoadScene(number);
    }
}
