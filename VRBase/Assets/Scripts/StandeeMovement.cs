using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandeeMovement : MonoBehaviour
{
    public Vector3 startMovement;
    public float movementSpeed = 1f;
    public bool isMoving = false;
    private Action OnMovementComplete; //Callback Method
    public bool firstMovement = true;

    public void StartMovement()
    {
        this.OnMovementComplete += HandleMovementComplete; //subscribe to event

        Vector3 targetPosition = transform.position + startMovement;
        // Ensure the coroutine is not already running
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveContinuous(targetPosition));
        }
    }

    private IEnumerator MoveContinuous(Vector3 _targetPosition)
    {
        while (Vector3.Distance(transform.position, new Vector3(_targetPosition.x, transform.position.y, _targetPosition.z)) > 0.2f)
        {
            // Move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_targetPosition.x, transform.position.y, _targetPosition.z), movementSpeed * Time.deltaTime);
            // Yield to the next frame
            yield return null;
        }
        isMoving = false;

        // Invoke the callback method if its the firstMovement
        OnMovementComplete?.Invoke();
    }
    private void HandleMovementComplete()
    {
        if (firstMovement)
        {
            StartCoroutine(MoveContinuous(Vector3.zero));
            firstMovement = false;
        }
    }
}
