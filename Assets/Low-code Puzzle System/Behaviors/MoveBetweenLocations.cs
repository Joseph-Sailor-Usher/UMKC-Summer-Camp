using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;

public class MoveBetweenLocations : MonoBehaviour {
    // How often to update the position while moving
    [Range(0.001f, 0.1f)]
    public float UpdateFrequency = 0.1f;
    // If movement can change before reaching a destination
    public bool preemption = false;
    // The speed of movement in meters per second
    public float speed = 1f;
    // The locations to move to and from
    public Locations locations;
    public int currentLocationIndex = 0;
    private IEnumerator moveToCoroutine;
    private bool isMoving = false;
    public List<Transform> transformsToOffset;
    // Events
    public UnityEvent onStartedMoving, onChangedTarget, onReachedLocation;
    public void MoveToPosition(Vector3 position) {
        if(moveToCoroutine != null) {
            StopCoroutine(moveToCoroutine);
            onChangedTarget.Invoke();
        } else {
            onStartedMoving.Invoke();
        }
        moveToCoroutine = MoveToPositionCoroutine(position, speed);
        StartCoroutine(moveToCoroutine);
    }
    public void MoveToNextPosition() {
        if(preemption == false) {
            if(isMoving == true) return;
            isMoving = true;
        }
        if (locations != null && locations.locations.Count > 0) {
            if (currentLocationIndex >= locations.locations.Count - 1) {
                currentLocationIndex = 0;
            } else {
                currentLocationIndex += 1;
            } 

            MoveToPosition(locations.locations[currentLocationIndex].position);
        }
    }
    public void MoveToIndexedPosition(int index) {
        if(preemption == false) {
            if(isMoving == true) return;
            isMoving = true;
        }
        if (locations != null && locations.locations.Count > 0) {
            if(currentLocationIndex < locations.locations.Count)
                currentLocationIndex = index;
            MoveToPosition(locations.locations[index].position);
        }
    }
    private IEnumerator MoveToPositionCoroutine(Vector3 targetPosition, float speed) {
        Vector3 startPosition = transform.position;
        float startTime = Time.time;
        float totalDistance = Vector3.Distance(startPosition, targetPosition);
        float timeToReachTarget = totalDistance / speed;
        float endTime = startTime + timeToReachTarget;
        while (Time.time < endTime) {
            float fractionOfJourney = (Time.time - startTime) / timeToReachTarget;
            Vector3 step = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            foreach (Transform child in transformsToOffset)
                child.transform.position += step - transform.position;
            transform.position = step;
            yield return new WaitForSeconds(UpdateFrequency);
        }
        transform.position = targetPosition;
        isMoving = false;
        onReachedLocation.Invoke();
    }

    public void AddTransformToOffset(Transform newChild)
    {
        if (transformsToOffset.Contains(newChild))
            return;
        transformsToOffset.Add(newChild);
    }
    public void RemoveTransformToOffset(Transform transformToRemove)
    {
        if (transformsToOffset.Contains(transformToRemove))
            transformsToOffset.Remove(transformToRemove);
    }
}
