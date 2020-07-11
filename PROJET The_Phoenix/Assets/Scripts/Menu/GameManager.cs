using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private string _currentLevelName = string.Empty;
    List<AsyncOperation> _loadOperations;
    public GameObject[] SystemPrefabs;
    private List<GameObject> _instanciedSystemPrefabs;
    bool fin = false;

    protected override void OnDestroy()
    {
        base.OnDestroy();
        for (int i = 0; i < _instanciedSystemPrefabs.Count; i++)
        {
            Destroy(_instanciedSystemPrefabs[i]);
        }
        _instanciedSystemPrefabs.Clear();
    }

    private void Start()
    {
        _loadOperations = new List<AsyncOperation>();
        
        _instanciedSystemPrefabs = new List<GameObject>();
        LoadLevel("LVL1");

        InstantiateSystemPrefabs();
    }

    void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; i++)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instanciedSystemPrefabs.Add(prefabInstance);
        }
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }
        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to Unload level " + levelName);
            return;
        }
        ao.completed += OnUnloadOperationComplete;
        _currentLevelName = string.Empty;
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);
            DontDestroyOnLoad(this.gameObject);
        }
        Debug.Log("Load Complete");
    }
    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Destruction Complete");
    }
}
