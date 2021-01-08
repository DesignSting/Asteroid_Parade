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

    public void SpawnAsteroid()
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
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnVector, Quaternion.identity);

        int destination = Random.Range(0, destinationTransforms.Count);

        newAsteroid.GetComponent<Asteroid>().StartMoving(destinationTransforms[destination]);
    }
}
