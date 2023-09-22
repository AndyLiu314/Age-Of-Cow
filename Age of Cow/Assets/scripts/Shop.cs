using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private UnitManager unitmanager;

    private void Start()
    {
        unitmanager = UnitManager.instance;
    }

    public void BuyChicken()
    {
        GameObject chickenPrefab = unitmanager.GetChicken(unitmanager.ChickenPrefab);
        UnitPlacement.Instance.SelectUnit(chickenPrefab);
    }

    public void BuyCow()
    {
       
    }
}
