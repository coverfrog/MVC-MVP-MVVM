using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SceneMainMenuContext
{
    public SceneMainMenuState state;
    [Space]
    public Button hostButton;
    public Button clientButton;
    public Button startButton;
}