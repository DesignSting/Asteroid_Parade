using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInfo : MonoBehaviour
{
    public AsteroidSize size;

    private Rigidbody thisRigid;
    private int scoreRecieved;
    private float health;
    private Color defaultColour;
    private Material thisMaterial;

    private bool hit;
    private bool goingUp;
    private float hitTimer;
    private float hitDuration = 0.05f;

    private void Awake()
    {
        thisRigid = GetComponent<Rigidbody>();
    }

    public void Hit()
    {
        hit = true;
        goingUp = true;
        hitTimer = 0;
        health -= 10;
    }

    public void SetAsteroid(Vector3 direction, bool isGeneral)
    {
        thisMaterial = GetComponent<MeshRenderer>().material;
        defaultColour = thisMaterial.color;
        int mass = 0;
        int velocity = 0;
        switch (size)
        {
            case AsteroidSize.Large:
                mass = Random.Range(120, 180);
                velocity = Random.Range(16000, 18000);
                health = 100;
                scoreRecieved = 15;
                break;
            case AsteroidSize.Medium:
                mass = Random.Range(70, 90);
                if (isGeneral)
                    velocity = Random.Range(10000, 13000);
                else
                    velocity = Random.Range(100, 200);
                health = 60;
                scoreRecieved = 35;
                break;
            case AsteroidSize.Small:
                mass = Random.Range(30, 55);
                if(isGeneral)
                    velocity = Random.Range(8000, 10000);
                else
                    velocity = Random.Range(50, 100);
                health = 40;
                scoreRecieved = 65;
                break;
        }
        thisRigid.mass = mass;
        thisRigid.AddForce(direction * velocity);
    }

    public void StartDestruction()
    {
        gameObject.SetActive(false);
        if (size != AsteroidSize.Small)
        {
            int toCreate = Random.Range(1, 4);

            float xAngle = 0;
            float yAngle = 0;

            Vector3 newPos = Vector3.zero;

            for (int i = 0; i < toCreate; i++)
            {
                switch (i)
                {
                    case 0:
                        newPos = new Vector3(transform.position.x - 6, transform.position.y + 6, 0);
                        xAngle = Random.Range(-180, 0);
                        yAngle = Random.Range(0, 180);
                        break;
                    case 1:
                        newPos = new Vector3(transform.position.x + 6, transform.position.y, 0);
                        xAngle = Random.Range(0, 180);
                        yAngle = Random.Range(0, 180);
                        break;
                    case 2:
                        newPos = new Vector3(transform.position.x - 6, transform.position.y - 6, 0);
                        xAngle = Random.Range(-180, 0);
                        yAngle = Random.Range(-180, 0);
                        break;
                }
                FindObjectOfType<GameManager>().SpawnAsteroid(newPos, new Vector3(xAngle, yAngle, 0), size);
            }
        }
        FindObjectOfType<UIManager>().AddToScore(scoreRecieved, GetComponentInParent<Asteroid>().colourSelected);
        Destroy(transform.parent.gameObject);
    }

    private void Update()
    {
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void LateUpdate()
    {
        if(hit)
        {
            if (goingUp)
            {
                hitTimer += Time.deltaTime;
                float step = hitTimer / hitDuration;

                thisMaterial.color = Color.Lerp(defaultColour, Color.white, step);
                if(hitTimer > hitDuration)
                {
                    goingUp = false;
                    hitTimer = 0;
                }

            }
            else
            {
                hitTimer += Time.deltaTime;
                float step = hitTimer / hitDuration;

                thisMaterial.color = Color.Lerp(Color.white, defaultColour, step);
                if (hitTimer > hitDuration)
                {
                    hit = false;
                    hitTimer = 0;
                    if(health == 0)
                    {
                        StartDestruction();
                    }
                }
            }

        }
    }
}

public enum AsteroidSize
{
    Large,
    Medium,
    Small
}
