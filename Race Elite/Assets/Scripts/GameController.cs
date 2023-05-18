using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitSpectator()
    {
        Debug.Log("Spectator");
        SceneManager.LoadSceneAsync("Spectator");
    }

    public void InitPlayer(){
        Debug.Log("Player");
        SceneManager.LoadSceneAsync("Player");
    }
}
