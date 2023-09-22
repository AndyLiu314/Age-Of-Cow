using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this speed as needed.

    void Update()
    {
        // Move the sprite to the right based on the constant speed.
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
