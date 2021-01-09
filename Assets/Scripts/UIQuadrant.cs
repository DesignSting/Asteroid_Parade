using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIQuadrant : MonoBehaviour
{
    public Quadrant thisquadrant;

    [Space]
    public TMP_Text scoreText;
    public Image colourWanted;
    public Colour currentColour;

    [Space]
    public TMP_Text oxygenText;
    public Image fullOxygenImage;

    private int currentScore;
    public float oxygenTimer;

    public void RecieveScoreUpdate(int score, Colour colour)
    {
        if (colour == currentColour)
        {
            score *= 2;
            NewColourNeeded();
        }
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }

    public void AddOxygen(float oxygen)
    {
        Debug.Log("Adding Oxygen");
        Debug.Log(oxygenTimer + " : " + oxygen);
        oxygenTimer += oxygen;
        if(oxygenTimer > 120)
        {
            oxygenTimer = 120;
        }
    }

    private void ChangeCurrentColourDisplayed()
    {
        switch (currentColour)
        {
            case Colour.Red:
                colourWanted.color = Color.red;
                break;
            case Colour.Green:
                colourWanted.color = Color.green;
                break;
            case Colour.Blue:
                colourWanted.color = Color.blue;
                break;
            case Colour.Yellow:
                colourWanted.color = Color.yellow;
                break;
        }
    }

    private void NewColourNeeded()
    {

    }

    private void OnEnable()
    {
        switch (thisquadrant)
        {
            case Quadrant.TopLeft:
                currentScore = FindObjectOfType<UIManager>().ReturnCurrentScore();
                currentColour = FindObjectOfType<UIManager>().ReturnCurrentColour();
                ChangeCurrentColourDisplayed();
                break;
            case Quadrant.TopRight:
                currentScore = FindObjectOfType<UIManager>().ReturnCurrentScore();
                currentColour = FindObjectOfType<UIManager>().ReturnCurrentColour();
                ChangeCurrentColourDisplayed();
                break;
            case Quadrant.BottomLeft:
                oxygenTimer = FindObjectOfType<UIManager>().ReturnCurrentOxygen();
                Debug.Log(oxygenTimer);
                break;
            case Quadrant.BottomRight:
                oxygenTimer = FindObjectOfType<UIManager>().ReturnCurrentOxygen();
                Debug.Log(oxygenTimer);
                break;
        }
    }

    private void OnDisable()
    {
        switch (thisquadrant)
        {
            case Quadrant.TopLeft:
                FindObjectOfType<UIManager>().SetCurrentScore(currentScore);
                FindObjectOfType<UIManager>().SetCurrentColour(currentColour);
                break;
            case Quadrant.TopRight:
                FindObjectOfType<UIManager>().SetCurrentScore(currentScore);
                FindObjectOfType<UIManager>().SetCurrentColour(currentColour);
                break;
            case Quadrant.BottomLeft:
                FindObjectOfType<UIManager>().SetOxygenTimer(oxygenTimer);
                break;
            case Quadrant.BottomRight:
                FindObjectOfType<UIManager>().SetOxygenTimer(oxygenTimer);
                break;
        }
    }

    private void Update()
    {
        if(thisquadrant == Quadrant.BottomLeft || thisquadrant == Quadrant.BottomRight)
        {
            oxygenTimer -= Time.deltaTime;
            float seconds = oxygenTimer % 60;
            int minutes = (int)oxygenTimer / 60;

            oxygenText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            fullOxygenImage.fillAmount = oxygenTimer / 120;
        }
    }
}
