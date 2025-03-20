using UnityEngine;

public class MainMenuManager : MonoBehaviour, IDataPersistence
{
    public static MainMenuManager Instance;

#pragma warning disable 0649
    [SerializeField] private SettingsManager _settingsManager;
#pragma warning restore 0649

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartFunc();
    }

    //via - link inpector
    public void PlayButton()
    {
        ProjectManager.EnterSceneByName("GamePlay");
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
        _settingsManager.OnStart();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}