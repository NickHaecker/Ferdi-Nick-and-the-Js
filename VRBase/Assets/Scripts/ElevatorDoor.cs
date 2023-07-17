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

    // Start is called before the first frame update
    void Start()
    {
        //_animator.SetBool("IsOpen", false);
    }

    // Update is called once per frame
    void Update()
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
        Debug.Log("ff");
        //_animator.SetBool("IsOpen", true);
        _animator.SetTrigger("Open");
    //_animator.tr
    }

    private void OnBeforeCloseScene()
    {
        //_animator.SetBool("IsOpen", false);
        _animator.SetTrigger("Close");
    }

    //public void AfterDoor

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
