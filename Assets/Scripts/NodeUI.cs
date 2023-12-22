using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;
    public TMP_Text upgradeCostText;
    public TMP_Text sellCostText;
    public Button upgradeButton;
    public Button sellButton;

    private void Awake()
    {
        ui.SetActive(false);
    }

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition(); //get build position takes the center of the node and offsets it with .5
        sellCostText.text = "SELL\n$" + target.turretBlueprint.GetSellValue();

        if (!target.isUpgraded)
        {
            upgradeCostText.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;

        }
        else
        {
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);
    }

    public void Hide() { ui.SetActive(false); }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }    
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
