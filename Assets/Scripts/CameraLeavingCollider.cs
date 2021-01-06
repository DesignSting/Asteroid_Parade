using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeavingCollider : MonoBehaviour
{
    public ColliderPosition position;

    private void Start()
    {
        GetComponentInParent<CameraController>().AddValue(position, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponentInParent<CameraController>().ChangePosition(position);
        }
    }
}

public enum ColliderPosition
{
    Top,
    Left,
    Right,
    Bottom
}
