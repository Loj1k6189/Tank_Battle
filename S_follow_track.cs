using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class S_follow_track : MonoBehaviour
{
    public GameObject Firepoint;
    public GameObject point;
    public float turretRotateSpeed;

    private void TurretRotate()
    {
        Firepoint.transform.LookAt(point.transform.position);
        point.transform.position = Vector3.MoveTowards(point.transform.position, point.transform.position, turretRotateSpeed);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurretRotate();
    }
}
