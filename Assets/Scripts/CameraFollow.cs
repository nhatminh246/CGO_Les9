using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float distance = 10f;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 5, 0);

    private void LateUpdate()
    {
        Vector3 behind = -player.forward;
        transform.position = player.position + behind * distance + offset;

        Vector3 directionPlayer = player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionPlayer);
    }
}
