using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool isTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player) || isTriggered)
        {
            return;
        }

        isTriggered = true;
        player.DropCube();
    }
}
