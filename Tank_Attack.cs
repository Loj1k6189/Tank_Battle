using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Attack : MonoBehaviour
{

    public GameObject shellPrefab;
    public GameObject collidePrefab;
    public KeyCode fireKey = KeyCode.Space;
    public KeyCode collideKey = KeyCode.Space;
    public float shellSpeed = 10;
    public float collideSpeed = 1;
    public AudioClip shotAudio;

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
            GameObject go = GameObject.Instantiate(shellPrefab, firePoint.position, firePoint.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
        }
        if (Input.GetKeyDown(collideKey))
        {
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
            GameObject go1 = GameObject.Instantiate(collidePrefab, firePoint.position, firePoint.rotation) as GameObject;
            go1.GetComponent<Rigidbody>().velocity = go1.transform.forward * collideSpeed;
        }
    }
}