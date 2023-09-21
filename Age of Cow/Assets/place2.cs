using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacement : MonoBehaviour
{
    public static UnitPlacement Instance;
    private GameObject selectedUnitPrefab; // Reference to the selected unit prefab.

    private void Awake()
    {
        Instance = this;
    }

    // Method to set the selected unit prefab.
    public void SelectUnit(GameObject unitPrefab)
    {
        selectedUnitPrefab = unitPrefab;
    }

    void Update()
    {
        // Check for left mouse button click.
        if (Input.GetMouseButtonDown(0))
        {
            // Check if a selected unit prefab exists.
            if (selectedUnitPrefab != null)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(selectedUnitPrefab, mousePosition, Quaternion.identity);
            }
        }
    }
}

