using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.Playables;

public class FileDataHandler
{
    private string _dataDiractionPath = "";
    private string _dataFileName = "";

    public FileDataHandler(string dataDiractionPath, string dataFileName)
    {
        _dataDiractionPath = dataDiractionPath;
        _dataFileName = dataFileName;
    }

    public GameData LoadData()
    {
        string fullDataPath = Path.Combine(_dataDiractionPath, _dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullDataPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullDataPath, FileMode.Open))
                {
                    using (StreamReader reader  = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error With Load Data To Path " + fullDataPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void SaveData(GameData gameData)
    {
        string fullDataPath = Path.Combine(_dataDiractionPath, _dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullDataPath));
            string dataToSave = JsonUtility.ToJson(gameData, true);
            using (FileStream stream = new FileStream(fullDataPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToSave);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error With Save Data To Path " + fullDataPath + "\n" + e);
        }
    }
}