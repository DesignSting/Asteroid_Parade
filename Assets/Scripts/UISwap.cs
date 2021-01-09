using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwap : MonoBehaviour
{
    public Quadrant thisQuadrant;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<UIManager>().ChangeQuadrant(thisQuadrant);
        }
    }
}

public enum Quadrant
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}
