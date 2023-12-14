using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    private Renderer rend;
    private Color startColor;
    private GameObject turret;
    public Vector3 positionOffset; //to fix the position of the turret that is built

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {        
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("You can not build here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

}
