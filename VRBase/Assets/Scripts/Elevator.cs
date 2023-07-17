using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Elevator : MonoBehaviour
{
    private static Elevator _instance;
    public static Elevator Instance { get { return _instance; } }

    [SerializeField]
    private List<ElevatorDoor> _doors;

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

        InitGame += OnInitGame;

    }

    private void OnInitGame()
    {
        foreach(ElevatorDoor elevatorDoor in _doors)
        {
            elevatorDoor.TakeElevator(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitGame?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

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
        if(i == 2)
        {
            CloseScene?.Invoke();
        }
    }
}
