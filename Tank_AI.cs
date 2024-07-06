using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Tank_AI : MonoBehaviour
{
    //自动寻路单元
    public NavMeshAgent tankMesh; //坦克自动寻路
    public float movedistance;
    public float speed;
    public float MoveTime;
    public GameObject[] enemyList;
    public string enemyTag;
    public Dictionary<float, GameObject> enemyDict;
    public List<float> distances;
    public GameObject mEnemy;


    //自动开火单元
    public float fireTime;
    public GameObject shell;
    public Transform FirePoint;
    public float shellSpeed;


    //自动瞄准单元
    public GameObject turret;
    public GameObject point;
    public float turretRotateSpeed;

    //音效单元
    public AudioClip shotAudio;


    // Start is called before the first frame update
    private void Start()
    {
        tankMesh.speed = speed;
        // StartCoroutine(randommove());
        StartCoroutine(fire());
        enemyDict = new Dictionary<float, GameObject>();
        distances = new List<float>();
    }

    private void TurretRotate()
    {
        turret.transform.LookAt(point.transform.position);
        point.transform.position = Vector3.MoveTowards(point.transform.position, mEnemy.transform.position, turretRotateSpeed);
    }


    private void GetEnemy()
    {
        for(int i=0;i<enemyList.Length;i++)
        {
            if (enemyList[i] != null)
            {
                if (!enemyDict.ContainsKey(Vector3.Distance(this.transform.position, enemyList[i].transform.position)))
                {
                    enemyDict.Add(Vector3.Distance(this.transform.position, enemyList[i].transform.position), enemyList[i].gameObject);
                }
                distances.Add(Vector3.Distance(this.transform.position, enemyList[i].transform.position));
            }
        }
        distances.Sort();
        mEnemy = enemyDict[distances[0]];

        enemyDict.Clear();
        distances.Clear();

    }

    /*
    IEnumerator randommove()
    {
        while(true)
        {
            Vector3 position = new Vector3(Random.Range(this.transform.position.x - movedistance, this.transform.position.x + movedistance), this.transform.position.y, Random.Range(this.transform.position.z - movedistance, this.transform.position.z + movedistance));
            tankMesh.SetDestination(position);
            yield return new WaitForSeconds(MoveTime);
            tankMesh.SetDestination(this.transform.position);
            yield return new WaitForSeconds(3);
        }
    }
    */

    IEnumerator fire()
    {
        while (true)
        {
            // 假设shellPrefab是一个子弹的预制体  
            GameObject bullet = Instantiate(shell, FirePoint.position, FirePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = bullet.transform.forward * shellSpeed;
            }

            // 等待fireTime秒再发射下一个子弹  
            yield return new WaitForSeconds(fireTime);
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
        }
    }

    /*
    IEnumerator Shellfly(GameObject shell)
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
            if (shell != null)
            {
                GameObject go = GameObject.Instantiate(shell, FirePoint.position, FirePoint.rotation) as GameObject;
                go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
            }
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        enemyList = GameObject.FindGameObjectsWithTag(enemyTag);

        GetEnemy();
        TurretRotate();

    }
}
