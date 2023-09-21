using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;
    
    void Awake()
    {
        instance= this;
    }

    public GameObject ChickenPrefab;

    private GameObject Chicken;
    public GameObject GetChicken(GameObject chickenPrefab)
    {
        return Chicken;
    }
    private GameObject Cow;
    public GameObject GetCow(GameObject CowPrefab)
    {
        return Cow;
    }
    public void SelectUnit(GameObject unit)
    {
       ChickenPrefab = unit;
    }
}
       
