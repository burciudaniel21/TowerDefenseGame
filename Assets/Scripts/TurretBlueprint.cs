using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //this allows unity to save and load the values inside this class (for example if you set a value in the editor without having this class Serializable, the values will be lost)
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;    
    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellValue()
    {
        return cost / 2;
    }
}
