using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawner;
    [SerializeField]
    private GameObject _spawnableObject;
    [SerializeField]
    private TutorialController _gameController;


    void Start()
    {
        _gameController.StartScene += OnStartScene;
        _gameController.Reset += ReSpawn;
        //ReSpawn();
    }

    private void OnStartScene()
    {
        //ReSpawn();
    }


    void Update()
    {
        
    }

    private void ReSpawn()
    {
        _spawnableObject.transform.position = _spawner.transform.position;
    }
}
