using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float destroyDelay = 7f; // Set the time delay before the GameObject is destroyed in seconds.

    private void Start()
    {
        // Schedule the self-destruction after the specified delay.
        Destroy(gameObject, destroyDelay);
    }
}
