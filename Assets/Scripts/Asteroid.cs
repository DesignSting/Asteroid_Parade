using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public List<GameObject> asteroidTypes = new List<GameObject>();
    public Colour colourSelected;


    private Material thisMaterial;
    public Rigidbody thisRigidbody;
    private MeshFilter thisFilter;

    private Vector3 direction;

    public void CreateGeneralAsteroid(Transform moveTowards)
    {
        int asteroid = Random.Range(0, asteroidTypes.Count);
        asteroidTypes[asteroid].SetActive(true);

        SetUpAsteroid();

        Vector3 dir = (transform.position - moveTowards.position).normalized;
        dir = -dir;

        StartMoving(dir, true);
    }

    public void CreateSpecificAsteroid(Vector3 direction, AsteroidSize asteroidSize)
    {
        List<GameObject> canUse = new List<GameObject>();
        AsteroidSize toFind = AsteroidSize.Large;
        if (asteroidSize == AsteroidSize.Large)
            toFind = AsteroidSize.Medium;
        else if (asteroidSize == AsteroidSize.Medium)
            toFind = AsteroidSize.Small;

        foreach (GameObject a in asteroidTypes)
        {
            if (a.GetComponentInChildren<AsteroidInfo>().size == toFind)
            {
                canUse.Add(a);
            }
        }

        int toUse = Random.Range(0, canUse.Count);
        canUse[toUse].SetActive(true);

        SetUpAsteroid();

        StartMoving(direction, false);
    }

    private void SetUpAsteroid()
    {
        thisRigidbody = GetComponentInChildren<Rigidbody>();
        thisMaterial = GetComponentInChildren<MeshRenderer>().material;

        int randColour = Random.Range(0, 4);

        switch (randColour)
        {
            case 0:
                thisMaterial.color = Color.red;
                break;
            case 1:
                thisMaterial.color = Color.green;
                break;
            case 2:
                thisMaterial.color = Color.blue;
                break;
            case 3:
                thisMaterial.color = Color.yellow;
                break;
        }
    }

    private void StartMoving(Vector3 direction, bool isGeneral)
    {
        GetComponentInChildren<AsteroidInfo>().SetAsteroid(direction, isGeneral);
    }
}

public enum Colour
{
    Red,
    Green,
    Blue,
    Yellow
}
