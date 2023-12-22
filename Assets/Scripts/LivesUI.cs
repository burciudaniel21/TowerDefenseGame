using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    [SerializeField]  TMP_Text livesText;
    // Update is called once per frame
    void Update()
    {
        livesText.text = "LIVES: " +PlayerStats.Lives.ToString() ;
    }
}
