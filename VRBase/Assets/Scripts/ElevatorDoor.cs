using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ElevatorDoor : MonoBehaviour
{
    public Action<ElevatorDoor> DoorClosed;
    public Action<ElevatorDoor> DoorOpened;


    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private bool _isOpen = false;


    void Start()
    {

    }

    public void TakeElevator(Elevator elevator)
    {
        elevator.AfterLoadScene += OnAfterLoadScene;
        elevator.BeforeCloseScene += OnBeforeCloseScene;

        DoorClosed += elevator.OnDoorClosed;
        DoorOpened += elevator.OnDoorOpened;
    }

    private void OnAfterLoadScene()
    {
        _animator.SetTrigger("Open");
    }

    private void OnBeforeCloseScene()
    {
        _animator.SetTrigger("Close");
    }

    public bool IsOpen()
    {
        return _isOpen;
    }

    public void OnDoorClosed()
    {
        _animator.SetTrigger("CloseIdle");

        _isOpen = false;

        DoorClosed?.Invoke(this);
    }

    public void OnDoorOpened()
    {
        _animator.SetTrigger("OpenIdle");

        _isOpen = true;

        DoorOpened?.Invoke(this);
    }
}
