using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float multiplyer = 1;
    public GameObject directionPointer;
    public GameObject crosshair;
    public GameObject bullet;
    public Transform bulletSpawnPoint;

    public bool teleportedVertical;
    public bool teleportedHorizontal;

    private Rigidbody thisRigidbody;

    private Vector3 mousePos;
    public bool tooClose;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!tooClose)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bulletCopy = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
                bulletCopy.transform.LookAt(mousePos);
                bulletCopy.GetComponentInChildren<BulletProjectile>().Shoot(mousePos);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 dir = (transform.position - directionPointer.transform.position).normalized;
            thisRigidbody.AddForce(-dir * multiplyer * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 dir = (transform.position - directionPointer.transform.position).normalized;
            thisRigidbody.AddForce(dir * multiplyer * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * multiplyer * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * multiplyer * Time.fixedDeltaTime);
        }
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        Debug.DrawLine(transform.position, mousePos);
        crosshair.transform.LookAt(mousePos);
    }
}
