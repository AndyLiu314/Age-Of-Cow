using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapObjectPlacement : MonoBehaviour
{
    public Tilemap tilemap; // Assign the Tilemap where you want to place objects in the Inspector.
    public GameObject objectToPlace; // Assign the GameObject prefab you want to place in the Inspector.

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Convert mouse position to world position.
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            // Place the object at the cell position.
            PlaceObject(cellPosition);
        }
    }

    private void PlaceObject(Vector3Int cellPosition)
    {
        // Instantiate the object at the specified position.
        Vector3 placementPos = tilemap.GetCellCenterWorld(cellPosition);
        GameObject placedObject = Instantiate(objectToPlace, placementPos, Quaternion.identity);

        // You can add further customization or logic here for the placed object, if needed.
    }
}
