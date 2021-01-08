using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public List<Color> coloursAvailable = new List<Color>();
    public List<GameObject> asteroidTypes = new List<GameObject>();

    private Material thisMaterial;
    public Rigidbody thisRigidbody;
    private MeshFilter thisFilter;

    public void StartMoving(Transform moveTowards)
    {
        int asteroid = Random.Range(0, asteroidTypes.Count);
        asteroidTypes[asteroid].SetActive(true);
        thisRigidbody = GetComponentInChildren<Rigidbody>();
        thisMaterial = GetComponentInChildren<MeshRenderer>().material;

        int colour = Random.Range(0, coloursAvailable.Count);
        thisMaterial.color = coloursAvailable[colour];

        Vector3 dir = (transform.position - moveTowards.position).normalized;
        dir = -dir;
        int velocity = Random.Range(7500, 12000);
        thisRigidbody.AddForce(dir * velocity);
    }
}
