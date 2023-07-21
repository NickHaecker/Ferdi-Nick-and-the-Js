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
    [SerializeField]
    private List<Reward> _rewards = new List<Reward>();
    [SerializeField]
    private List<GameObject> _rewardItems = new List<GameObject>();

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

    void Start()
    {
        InitGame?.Invoke();

        
    }

    public void ValidateStartTutorial()
    {
        StartCoroutine(StartTutorial());
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(5f);

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
    }

    public void RemoveMinigameController(MiniGameController miniGameController)
    {
        BeforeCloseScene?.Invoke();

        StartScene -= miniGameController.OnStartScene;
    }

    private void OnCloseScene()
    {
        CloseScene -= _gameController.OnCloseScene;

        _gameController.RemoveListener();

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
            SkyboxController.Instance.ChangeSkybox();
            StartCoroutine(SwitchScene());
        }

    }

    public void TakeReward(Reward reward = null)
    {
        if(reward == null)
        {
            return;
        }

        foreach (Reward r in _rewards)
        {
            if (r.ID == reward.ID)
            {
                foreach (GameObject item in _rewardItems)
                {
                    if (r.Item.name == item.name)
                    {
                        item.SetActive(true);
                    }
                }
            }
        }
    }

    IEnumerator SwitchScene()
    {
        //ToDo: Hier  müssen wir noch definieren wann wir die szene switchen also was dazwischen passiert und wann der Wechsel zum neuen Level stattfindet
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
