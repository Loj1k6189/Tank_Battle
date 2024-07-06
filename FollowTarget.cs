using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private Camera camera;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - (player1.position + player2.position) / 2;
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null)
        {
            transform.position = offset + player2.position ;
            return;
        }
        if (player2 == null)
        {
            transform.position = offset + player1.position;
            return;
        }
        float distance = Vector3.Distance(player1.position, player2.position);
        transform.position = offset + (player1.position + player2.position) / 2;
        if (distance < 7f)
            return;
        float size = distance * 0.875f;
        camera.orthographicSize = size;

    }
}
