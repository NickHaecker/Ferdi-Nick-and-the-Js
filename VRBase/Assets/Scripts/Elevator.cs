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
    [SerializeField]
    private Animator _animator;

    public Action InitGame;
    public Action RestartGame;
    public Action BeforeLoadScene;
    public Action AfterLoadScene;
    public Action StartScene;
    public Action CloseScene;
    public Action BeforeCloseScene;
    public AudioSource[] audioSources;

    private void Awake()
    {
        _instance = this;
        _animator.enabled = false;
        StartScene += OnStartScene;
        CloseScene += OnCloseScene;
        InitGame += OnInitGame;
        BeforeLoadScene += OnBeforeLoadScene;
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
        audioSources = GetComponents<AudioSource>();
        StartCoroutine(StartTutorial());
    }
    public void OnBeforeLoadScene()
    {
        audioSources[0].Play();
        audioSources[2].Stop();
    }
    public void ValidateStartTutorial()
    {
        StartCoroutine(StartTutorial());
    }

    IEnumerator StartTutorial()
    {
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().Play();
        audioSources[1].Stop();
        yield return new WaitForSeconds(17f);
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

        _animator.enabled = true;

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
            audioSources[2].Play();
            SkyboxController.Instance.ChangeSkybox();
            StartCoroutine(SwitchScene());
        }

    }

    public void TakeReward(Reward reward = null)
    {

        if (reward == null)
        {
            return;
        }
        Debug.Log(reward.Item);
        //foreach (Reward r in _rewards)
        //{
        //    if (r.ID == reward.ID)
        //    {
        //        foreach (GameObject item in _rewardItems)
        //        {
        //            if (r.Item == item.name)
        //            {
        //                item.SetActive(true);
        //            }
        //        }
        //    }
        //}
        foreach (GameObject gameObject in _rewardItems)
        {
            if (gameObject.name == reward.Item)
            {
                gameObject.SetActive(true);
            }
        }
    }

    IEnumerator SwitchScene()
    {
        //ToDo: Hier  m�ssen wir noch definieren wann wir die szene switchen also was dazwischen passiert und wann der Wechsel zum neuen Level stattfindet
        yield return new WaitForSeconds(5f);

        if (_levelData.Next != null)
        {
            _levelData = _levelData.Next;

            _animator.enabled = false;

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
