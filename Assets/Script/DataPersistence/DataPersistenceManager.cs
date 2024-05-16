using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than One Data");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        ResetAgentPosition();      
    }

    private void ResetAgentPosition()
    {
        // Reset agent position to the position stored in game data
        GameObject agentObject = GameObject.FindGameObjectWithTag("Agent");
        if (agentObject != null)
        {
            agentObject.transform.position = gameData.agentPosition;
        }
        else
        {
            Debug.LogError("Agent GameObject not found in the scene.");
        }
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No Data found");
            NewGame();
        }
        else
        {
            ToggleMenuMessages(false);
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    //private void OnApplicationQuit()
    //{
        //SaveGame();
    //}

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    private void ToggleMenuMessages(bool setActive)
    {
        GameObject[] menuMessages = GameObject.FindGameObjectsWithTag("MenuMessage");
        foreach (GameObject message in menuMessages)
        {
            message.SetActive(setActive);
        }
    }
}
