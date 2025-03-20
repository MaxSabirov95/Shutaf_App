using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // -- Settings
    public int fpsIndex;
    public int musicOnOff;
    public int sfxOnOff;
    public int hapticOnOff;

    public GameData()
    {
        SetSettings();
    }

    private void SetSettings()
    {
        this.fpsIndex = 1; // 60fps
        this.musicOnOff = 1; // On
        this.sfxOnOff = 1; // On
        this.hapticOnOff = 1; // On
    }
}