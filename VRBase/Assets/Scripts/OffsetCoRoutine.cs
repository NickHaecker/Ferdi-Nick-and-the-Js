using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetCoRoutine : MonoBehaviour
{
    [SerializeField]
    private Rigidbody obj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Offset());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Offset()
    {
        yield return new WaitForSeconds(7.5f);
        obj.isKinematic = false;
    }
}
