using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public float lifeSpan = 5;

    private Rigidbody thisRigidbody;
    private float timer;

    public void Shoot(Vector3 mousePos)
    {
        Vector3 dir = (transform.position - mousePos).normalized;
        thisRigidbody.AddForce(dir * -1000);
    }

    private void Awake()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > lifeSpan)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
