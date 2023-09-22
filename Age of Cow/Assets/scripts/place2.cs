using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnitPlacement : MonoBehaviour
{
    public static UnitPlacement Instance;
    public Tilemap laneTilemap; // Reference to the Tilemap representing the lane.
    private GameObject selectedUnitPrefab; // Reference to the selected unit prefab.
    public float yOffset = 1.0f; // Y-axis offset for unit placement.
    private LayerMask unitLayer; // Layer mask for detecting units.
    private float lastPlacementTime = 0f;
    public float placementCooldown = 1f; // Cooldown time in seconds.

    private void Awake()
    {
        Instance = this;
        unitLayer = LayerMask.GetMask("Units"); // Set this to the layer where your units are placed.
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
                // Calculate the time elapsed since the last placement.
                float timeSinceLastPlacement = Time.time - lastPlacementTime;

                // Check if the cooldown time has passed.
                if (timeSinceLastPlacement >= placementCooldown)
                {
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3Int cellPos = laneTilemap.WorldToCell(mouseWorldPos);

                    // Check if the clicked position is within the bounds of the lane's Tilemap.
                    if (laneTilemap.HasTile(cellPos))
                    {
                        // Calculate the middle position of the lane on the y-axis with an offset.
                        Vector3 laneBoundsMin = laneTilemap.localBounds.min;
                        Vector3 middlePosition = new Vector3(laneBoundsMin.x, laneBoundsMin.y + yOffset, 0f);

                        // Check if there's a unit at the target cell.
                        Collider2D[] colliders = Physics2D.OverlapCircleAll(middlePosition, 0.1f, unitLayer);

                        // If there are no colliders in the target cell, instantiate the unit.
                        if (colliders.Length == 0)
                        {
                            Instantiate(selectedUnitPrefab, middlePosition, Quaternion.identity);
                            lastPlacementTime = Time.time; // Update the last placement time.
                        }
                    }
                }
            }
        }
    }
}
