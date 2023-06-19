using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    public Vector3 movement;

    void Update()
    {
        movement = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        transform.Translate(movement * Time.deltaTime * speed, Space.World);
    }
}
