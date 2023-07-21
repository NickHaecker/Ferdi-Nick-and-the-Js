using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private static GravityController _instance;

    public static GravityController Instance { get { return _instance; } }

    [SerializeField]
    private List<Flyable> _grabableObjects = new List<Flyable>();


    void Start()
    {

    }

    private void Awake()
    {
        _instance = this;
    }


    void Update()
    {

    }

    public void EnterOrbit()
    {
        foreach (Flyable flyable in _grabableObjects)
        {
            flyable.PrepareOrbit();
            flyable.Orbit();
        }
    }
    public void ExitOrbit()
    {
        foreach (Flyable flyable in _grabableObjects)
        {
            flyable.Ground();
        }
    }

    public void AddRidgidbody(Flyable rigidbody)
    {
        _grabableObjects.Add(rigidbody);
    }
    public void RemoveRidgidbody(Flyable rigidbody)
    {
        _grabableObjects.Remove(rigidbody);
    }
}
