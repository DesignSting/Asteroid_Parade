using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTooClose : MonoBehaviour
{
    private void OnMouseEnter()
    {
        GetComponentInParent<PlayerController>().tooClose = true;
    }

    private void OnMouseExit()
    {
        GetComponentInParent<PlayerController>().tooClose = false;
    }
}
