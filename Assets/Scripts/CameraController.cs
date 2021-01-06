using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public Image crosshair;


    private BoxCollider boxCollider;

    private float minXValue;
    private float maxXValue;
    private float minYValue;
    private float maxYValue;

    public void ChangePosition(ColliderPosition position)
    {
        Vector3 playerPos = player.transform.position;
        if (!player.teleportedVertical)
        {
            switch (position)
            {
                case ColliderPosition.Top:
                    player.transform.position = new Vector3(playerPos.x, minYValue, 0);
                    player.teleportedVertical = true;
                    break;
                case ColliderPosition.Bottom:
                    player.transform.position = new Vector3(playerPos.x, maxYValue, 0);
                    player.teleportedVertical = true;
                    break;
            }
            
        }

        if(!player.teleportedHorizontal)
        {
            switch (position)
            {
                case ColliderPosition.Left:
                    player.transform.position = new Vector3(maxXValue, playerPos.y, 0);
                    player.teleportedHorizontal = true;
                    break;
                case ColliderPosition.Right:
                    player.transform.position = new Vector3(minXValue, playerPos.y, 0);
                    player.teleportedHorizontal = true;
                    break;
            }
            
        }
    }

    public void JustTeleported()
    {
        player.teleportedVertical = false;
        player.teleportedHorizontal = false;
    }

    public void AddValue(ColliderPosition position, Transform t)
    {
        switch (position)
        {
            case ColliderPosition.Top:
                maxYValue = t.position.y;
                break;
            case ColliderPosition.Left:
                minXValue = t.position.x;
                break;
            case ColliderPosition.Right:
                maxXValue = t.position.x;
                break;
            case ColliderPosition.Bottom:
                minYValue = t.position.y;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        JustTeleported();
    }
}
