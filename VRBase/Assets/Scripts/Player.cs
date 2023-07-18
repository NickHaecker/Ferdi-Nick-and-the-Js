using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    private static Player _instance = null;

    public static Player Instance { get { return _instance; } }

    [SerializeField] private XRInteractionManager _interactionManager;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    public XRInteractionManager GetInteractionManager() { return _interactionManager; }

    // Update is called once per frame
    void Update()
    {

    }
}
