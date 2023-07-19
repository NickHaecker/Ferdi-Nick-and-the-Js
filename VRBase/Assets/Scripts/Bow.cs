using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class Bow : XRGrabInteractable
{
    private bool isGrabbed = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!isGrabbed)
        {
            base.OnSelectEntered(args);
            isGrabbed = true;
            Debug.Log("Bow grabbed");
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false;
        Debug.Log("Bow released");
    }
}
