using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    private static Elevator _instance;
    public static Elevator Instance { get { return _instance; } }

    [SerializeField]
    private List<ElevatorDoor> _doors;
    [SerializeField]
    private Transform _sceneHierachy;
    [SerializeField]
    private MiniGameController _gameController;
    [SerializeField]
    private LevelData _levelData;

    public Action InitGame;
    public Action RestartGame;
    public Action BeforeLoadScene;
    public Action AfterLoadScene;
    public Action StartScene;
    public Action CloseScene;
    public Action BeforeCloseScene;

    private void Awake()
    {
        _instance = this;

        StartScene += OnStartScene;
        CloseScene += OnCloseScene;
        InitGame += OnInitGame;
    }

    private void OnInitGame()
    {
        foreach (ElevatorDoor elevatorDoor in _doors)
        {
            elevatorDoor.TakeElevator(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitGame?.Invoke();

        StartCoroutine(StartTutorial());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(20f);

        string name = _levelData.Name;

        LoadScene(name);
    }

    private void LoadScene(string sceneName)
    {
        BeforeLoadScene?.Invoke();

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);


    }

    public void TakeMinigameController(MiniGameController miniGameController)
    {
        AfterLoadScene?.Invoke();

        StartScene += miniGameController.OnStartScene;
        CloseScene += miniGameController.OnCloseScene;

        _gameController = miniGameController;

        //StartScene?.Invoke();
    }

    public void RemoveMinigameController(MiniGameController miniGameController)
    {
        BeforeCloseScene?.Invoke();

        StartScene -= miniGameController.OnStartScene;

        //CloseScene?.Invoke();


    }

    private void OnCloseScene()
    {
        CloseScene -= _gameController.OnCloseScene;

        _gameController = null;

        UnloadScene(_levelData.Name);
    }

    private void OnStartScene()
    {

    }

    private void UnloadScene(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

        asyncOperation.completed += OnCompleteUnload;
    }

    private void OnCompleteUnload(AsyncOperation asyncOperation)
    {
        asyncOperation.completed -= OnCompleteUnload;

        if (asyncOperation.isDone)
        {
            StartCoroutine(SwitchScene());
        }

    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(5f);

        if (_levelData.Next != null)
        {
            _levelData = _levelData.Next;

            LoadScene(_levelData.Name);
        }
    }

    public void OnDoorOpened(ElevatorDoor door)
    {
        int i = 0;
        foreach (ElevatorDoor eD in _doors)
        {
            if (eD.IsOpen())
            {
                i++;
            }
        }
        if (i == 2)
        {
            StartScene?.Invoke();
        }
    }
    public void OnDoorClosed(ElevatorDoor door)
    {
        int i = 0;
        foreach (ElevatorDoor eD in _doors)
        {
            if (!eD.IsOpen())
            {
                i++;
            }
        }
        if (i == 2)
        {
            CloseScene?.Invoke();
        }
    }
}
