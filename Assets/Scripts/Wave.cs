using UnityEngine;

[System.Serializable] //allows instances of that class to be displayed and edited in the Unity Inspector window.
                      //This attribute enables Unity to serialize the data within that class so that it can be accessed and modified within the Unity Editor.
public class Wave
{
    public GameObject enemy;
    public int count;
    public float spawnRate;


}
