using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guard : MonoBehaviour
{
    public GameObject shieldPrefab;
    public GameObject player;
    private GameObject currentShield = null;
    public KeyCode fireKey = KeyCode.K;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void fangyu()
    {
        if (Input.GetKeyDown(fireKey))
        {
            if (true)
            {
                //player.shells -= 1;
                //shellSlider.value = (float)shells / shelltotal;
                if (currentShield == null)
                {
                    //player.shells -= 1;
                    //shellSlider.value = (float)shells / shelltotal;
                    currentShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);

                    currentShield.transform.localPosition = new Vector3(0, 0, 0);
                    currentShield.transform.localPosition = Vector3.zero;

                    Invoke("RemoveShield", 5f);
                }

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
