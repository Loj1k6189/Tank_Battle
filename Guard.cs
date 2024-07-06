using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public GameObject shieldPrefab;

    private GameObject currentShield = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BuffGuard"))
        {
            Destroy(other.gameObject);

            if (currentShield == null)
            {
                currentShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);

                currentShield.transform.localPosition = new Vector3(0, 0, 0); 
                currentShield.transform.localPosition = Vector3.zero; 

                Invoke("RemoveShield", 5f);
            }
        }
    }

    private void RemoveShield()
    {
        if (currentShield != null)
        {
            Destroy(currentShield);
            currentShield = null;
        }
    }
}
