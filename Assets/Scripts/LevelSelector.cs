using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader Fader;

    public void SelectLevel(string levelName)
    {
        Fader.FadeTo(levelName);
    }

}
