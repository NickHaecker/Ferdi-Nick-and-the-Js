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
        Vector2 randomCircle = UnityEngine.Random.insideUnitCircle.normalized * Mathf.Sqrt(UnityEngine.Random.Range(0f, 1f)) * 3;
        Vector3 randomPosition = new Vector3(randomCircle.x, 0, randomCircle.y) + _spawner.transform.position;

        _spawnableObject.transform.position = randomPosition;
    }
}
