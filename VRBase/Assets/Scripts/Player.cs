using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    private static Player _instance = null;

    public static Player Instance { get { return _instance; } }

    [SerializeField] private XRInteractionManager _interactionManager;
    [SerializeField]
    private List<Hand> _hands = new List<Hand>();

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

    public void AddListener(IHitableListener hitableListener)
    {
        foreach (Hand hand in _hands)
        {
            hand.Hit += (hitable) => hitableListener(hitable);
        }
    }
    public void RemoveListener(IHitableListener hitableListener)
    {
        foreach (Hand hand in _hands)
        {
            hand.Hit -= (hitable) => hitableListener(hitable);
        }
    }

    public void ActivateHands()
    {
        foreach (Hand hand in _hands)
        {
            hand.enabled = true;
        }
    }
    public void DeactivateHands()
    {
        foreach (Hand hand in _hands)
        {
            hand.enabled = false;
        }
    }
}
