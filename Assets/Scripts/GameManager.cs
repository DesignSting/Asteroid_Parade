using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoxCollider topCollider;
    public BoxCollider bottomCollider;
    public BoxCollider leftCollider;
    public BoxCollider rightCollider;

    public GameObject asteroidPrefab;
    public GameObject oxygenPrefab;

    public List<Transform> destinationTransforms = new List<Transform>();

    private float timer;
    private float timerDuration = 15f;

    private float oxygenSpawnTimer;
    private float oxygenSpawnDuration = 3f;

    public void SpawnObject(bool isAsteroid)
    {
        int spawnPos = Random.Range(0, 4);
        BoxCollider spawnCollider = null;
        switch(spawnPos)
        {
            case 0:
                spawnCollider = topCollider;
                break;
            case 1:
                spawnCollider = bottomCollider;
                break;
            case 2:
                spawnCollider = leftCollider;
                break;
            case 3:
                spawnCollider = rightCollider;
                break;
        }

        float xSize = spawnCollider.size.x;
        float ySize = spawnCollider.size.y;

        float xRand = Random.Range(-xSize / 2, xSize / 2);
        float yRand = Random.Range(-ySize / 2, ySize / 2);

        Transform spawnTransform = spawnCollider.transform;
        Vector3 spawnVector = spawnCollider.transform.position;

        spawnVector = new Vector3(spawnVector.x + xRand, spawnVector.y + yRand, 0);
        int destination = Random.Range(0, destinationTransforms.Count);

        if (isAsteroid)
        {
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnVector, Quaternion.identity);
            newAsteroid.GetComponent<Asteroid>().CreateGeneralAsteroid(destinationTransforms[destination]);
        }
        else
        {
            GameObject newOxygen = Instantiate(oxygenPrefab, spawnVector, Quaternion.identity);
            newOxygen.GetComponentInChildren<OxygenContainer>().CreateOxygenContainer(destinationTransforms[destination]);
        }
    }

    public void SpawnAsteroid(Vector3 position, Vector3 direction, AsteroidSize asteroidSize)
    {
        GameObject newAsteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
        newAsteroid.GetComponent<Asteroid>().CreateSpecificAsteroid(direction, asteroidSize);
    }

    private void Start()
    {
        //SpawnObject(true);
        //SpawnObject(true);
        //SpawnObject(true);
        //SpawnObject(true);
        //SpawnObject(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        oxygenSpawnTimer += Time.deltaTime;
        if(timer > timerDuration)
        {
            SpawnObject(true);
            timer = 0;
            timerDuration -= 0.05f;
        }

        if(oxygenSpawnTimer > oxygenSpawnDuration)
        {
            SpawnObject(false);
            oxygenSpawnTimer = 0;
        }
    }
}
