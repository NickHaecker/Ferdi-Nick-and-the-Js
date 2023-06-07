using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance = null;
    public static SceneController Instance { get { return _instance; } }
    [SerializeField]
    public BuildType BuildType;
    private void Awake()
    {
        _instance = this;
    }
}
