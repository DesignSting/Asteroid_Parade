using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIQuadrant topLeftPanel;
    public UIQuadrant topRightPanel;
    public UIQuadrant bottomLeftPanel;
    public UIQuadrant bottomRightPanel;

    [Space]
    public Colour selectedColour;

    private bool topLeft;
    private bool bottomLeft;


    private float oxygenTimer = 120f;
    private int currentScore;

    public void ChangeQuadrant(Quadrant newQuadrant)
    {
        switch (newQuadrant)
        {
            case Quadrant.TopLeft:
                topLeft = false;
                Debug.Log("TopLeft");
                break;
            case Quadrant.TopRight:
                topLeft = true;
                Debug.Log("TopRight");
                break;
            case Quadrant.BottomLeft:
                bottomLeft = false;
                Debug.Log("BottomLeft");
                break;
            case Quadrant.BottomRight:
                bottomLeft = true;
                Debug.Log("BottomRight");
                break;
        }

        if(topLeft)
        {
            topRightPanel.gameObject.SetActive(false);
            topLeftPanel.gameObject.SetActive(true);
        }
        else
        {
            topLeftPanel.gameObject.SetActive(false);
            topRightPanel.gameObject.SetActive(true);
        }

        if(bottomLeft)
        {
            bottomRightPanel.gameObject.SetActive(false);
            bottomLeftPanel.gameObject.SetActive(true);
        }
        else
        {
            bottomLeftPanel.gameObject.SetActive(false);
            bottomRightPanel.gameObject.SetActive(true);
        }
    }

    public void AddToScore(int score, Colour colour)
    {
        if(topLeft)
        {
            topRightPanel.RecieveScoreUpdate(score, colour);
        }
        else
        {
            topLeftPanel.RecieveScoreUpdate(score, colour);
        }
    }

    public void AddToOxygen(float oxygen)
    {
        if (!bottomLeft)
        {
            bottomRightPanel.AddOxygen(oxygen);
        }
        else
        {
            bottomLeftPanel.AddOxygen(oxygen);
        }
    }

    public void SetCurrentScore(int current)
    {
        currentScore = current;
    }

    public int ReturnCurrentScore()
    {
        return currentScore;
    }

    public Colour ReturnCurrentColour()
    {
        return selectedColour;
    }

    public void SetCurrentColour(Colour c)
    {
        selectedColour = c;
    }

    public void SetOxygenTimer(float oxygenTimer)
    {
        this.oxygenTimer = oxygenTimer;
    }

    public float ReturnCurrentOxygen()
    {
        return oxygenTimer;
    }

    private void Start()
    {
        topLeftPanel.gameObject.SetActive(true);
        bottomRightPanel.gameObject.SetActive(true);
    }

    private void Awake()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                selectedColour = Colour.Blue;
                break;
            case 1:
                selectedColour = Colour.Green;
                break;
            case 2:
                selectedColour = Colour.Red;
                break;
            case 3:
                selectedColour = Colour.Yellow;
                break;
        }
    }
}
