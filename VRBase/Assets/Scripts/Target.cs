using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int ring;
    public void Hit()
    {
        switch (ring)
        {
            case 1:
                Debug.Log("1");
                break;
            case 2: 
                Debug.Log("2");
                break;
            case 3:
                Debug.Log("3");
                break;
            case 4:
                Debug.Log("4");
                break;
            case 5:
                Debug.Log("5");
                break;
        }
    }
}
