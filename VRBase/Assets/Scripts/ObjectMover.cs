using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectMover : MonoBehaviour
{
    [SerializeField]
    private GameObject _target = null;
    [SerializeField]
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) return;

        if (Vector3.Distance(transform.position, _target.transform.position) <= 0.2)
        {
            _target = null;

            return;
        }

        Vector3 newPosition = Vector3.Lerp(transform.position, _target.transform.position, speed * Time.deltaTime);

        transform.position = newPosition;
    }

    public void TakeTarget(GameObject target)
    {
        _target = target;
    }

}
