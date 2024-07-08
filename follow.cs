using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    private Camera cam;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        if (player1 != null && player2 != null)
        {
            offset = transform.position - (player1.position + player2.position) / 2;
        }
        else if (player1 != null)
        {
            offset = transform.position - player1.position;
        }
        else if (player2 != null)
        {
            offset = transform.position - player2.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player2 == null && player1 == null) return;
        if (player1 != null && player2 != null)
        {
            transform.position = (player1.position + player2.position) / 2 + offset;
            float distance = Vector3.Distance(player1.position, player2.position);
            if (distance > 0.5f)
            {
                float size = distance * 0.875f;
                cam.orthographicSize = size;
            }
        }
        else if (player1 == null && player2 != null)
        {
            transform.position = player2.position + offset;
        }
        else if (player1 != null && player2 == null)
        {
            transform.position = player1.position + offset;
        }
    }
}

