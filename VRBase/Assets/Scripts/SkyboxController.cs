using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    private static SkyboxController _instance;

    public static SkyboxController Instance { get { return _instance; } }

    [SerializeField]
    private Material _skybox;

    public void ChangeSkybox(Material skybox = null)
    {
        if (skybox == null)
        {
            RenderSettings.skybox = _skybox;
        }
        else
        {
            RenderSettings.skybox = skybox;
        }
    }

    private void Start()
    {
        _skybox = RenderSettings.skybox;
    }

    private void Awake()
    {
        _instance = this;
    }
}
