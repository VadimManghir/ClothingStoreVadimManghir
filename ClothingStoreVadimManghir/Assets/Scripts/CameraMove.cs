using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    void Update()
    {
        if (player == null)
        { return; }

        if (Distance() > 4)
        {
            Vector3 playerPosition = player.position;
            playerPosition.z = -10;
            transform.position = Vector3.Lerp(transform.position, playerPosition, 0.05f);
        }
    }

    public float Distance()
    {
        return Math.Abs(Vector3.Distance(player.position, transform.position));
    }
}
