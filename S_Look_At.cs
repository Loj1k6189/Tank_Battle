using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Look_At : MonoBehaviour
{
    public GameObject enemy;
    public Transform Firepoint;
    public Rigidbody shell;
    public float ShellSpeed = 1.0f;
    public float attackrange = 10.0f;
    public Transform target;

    private float cun_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null && GameObject.FindWithTag("Player")) target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.Find("Tank"); //สตภýปฏ  
        if (target == null)
            return;
        if (!CanSeeTarget())
            return;
        var targetPoint = target.position;
        var targetRotation = Quaternion.LookRotation(targetPoint - enemy.transform.position, Vector3.up);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, targetRotation, (float)((float)Time.deltaTime * 2.0));
        var forward = enemy.transform.TransformDirection(Vector3.forward);
        var targetDir = enemy.transform.position - target.position;
        if ((Vector3.Angle(forward, targetDir) < 10.0) || ((Vector3.Angle(forward, targetDir) > -10.0)))
        {
            cun_time++;
            if (cun_time == 260)
            {
                Rigidbody clone;
                clone = Instantiate(shell, Firepoint.transform.position, Firepoint.transform.rotation);
                clone.velocity = enemy.transform.TransformDirection(Vector3.forward * ShellSpeed);
                cun_time = 0;
            }
        }
        if ((Vector3.Distance(transform.position, target.position) < attackrange)) 
        {
            var targetPoint1 = target.position;
            var targetRotation1 = Quaternion.LookRotation(targetPoint1 - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation1, (float)(Time.deltaTime * 1.0));
            transform.Translate(Vector3.forward * 0.05f);
        }
    }

    public bool CanSeeTarget()
    {
        if (target == null)
            return false;
        if (Vector3.Distance(transform.position, target.position) > attackrange)
            return false;
        RaycastHit hit;
        bool hasLineOfSight = Physics.Linecast(transform.position, target.position, out hit);
        if (hasLineOfSight)
            return hit.transform == target.transform; 
        return false;
    }
}
