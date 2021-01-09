using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenContainer : MonoBehaviour
{
    public float oxygenAmount;

    public void CreateOxygenContainer(Transform dir)
    {
        Vector2 direction = -dir.position;
        GetComponent<Rigidbody>().AddForce(direction * 20);
    }

    private void Start()
    {
        oxygenAmount = Random.Range(10, 45);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<UIManager>().AddToOxygen(oxygenAmount);
            Destroy(transform.parent.gameObject);
        }
    }
}
