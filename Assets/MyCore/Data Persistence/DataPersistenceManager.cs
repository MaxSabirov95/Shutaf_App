using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
#pragma warning disable 0649
    [Header("File Storage Config")]
    [SerializeField] private string _fileName = "GameData";
#pragma warning restore 0649

    private FileDataHandler _fileDataHandler;

    public static DataPersistenceManager Instance;
    private List<IDataPersistence> dataPersistenceObjects;

    private GameData gamedata;

    private void Awake()
    {
        Instance = this;
    }

    public void StartLoadingData()
    {
        Utils.DebugLog(Application.persistentDataPath);
        this._fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
        this.dataPersistenceObjects = FindAllDataPresistenceObjects();
        LoadGameData();
    }

    public void NewGame()
    {
        this.gamedata = new GameData();
    }

    public void LoadGameData()
    {
        this.gamedata = _fileDataHandler.LoadData();

        if (this.gamedata == null)
        {
            Utils.DebugLog("No Game Data Found. Starting New Game");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadGameData(gamedata);
        }
    }

    public void SaveGameData()
    {
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.SaveGameData(ref gamedata);
        }

        _fileDataHandler.SaveData(gamedata);
    }

    private List<IDataPersistence> FindAllDataPresistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
