using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour, IDataPersistence
{
    public static GamePlayManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartFunc();
    }

    //via - link inpector
    public void ReplayButton()
    {
        ProjectManager.EnterSceneByName("GamePlay");
    }

    //via - link inpector
    public void ExitButton()
    {
        ProjectManager.EnterSceneByName("MainMenu");
    }

    public void LoadGameData(GameData gameData)
    {
        // Nothing Here
    }

    public void SaveGameData(ref GameData gameData)
    {
        // Nothing Here
    }

    private void StartFunc()
    {
        DataPersistenceManager.Instance.StartLoadingData();
        if (GameCurrentData.HapticOnOff == 1)
            Vibration.Init();
        AudioManager.Instance.SetAudio();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
