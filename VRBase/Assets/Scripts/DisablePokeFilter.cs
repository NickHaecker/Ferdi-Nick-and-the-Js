using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class DisablePokeFilter : MonoBehaviour
{
    public void DisableButton()
    {
        GetComponent<XRPokeFilter>().enabled = false;
    }
}
