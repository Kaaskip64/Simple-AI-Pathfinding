using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusIcon : MonoBehaviour
{
    public Transform agentPosition;

    public Vector3 offset;

    void Update()
    {
        transform.position = agentPosition.position + offset;

        transform.up = Camera.main.transform.position - transform.position;
        transform.forward = -Camera.main.transform.up;
    }
}
