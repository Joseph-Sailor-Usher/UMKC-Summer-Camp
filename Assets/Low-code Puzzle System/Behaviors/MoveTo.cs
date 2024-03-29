using System.Collections;
using UnityEngine;
public class MoveTo : MonoBehaviour {
    private IEnumerator moveToCoroutine;
    [Range(0.01f, 1f)]
    public float UpdateFrequency = 0.1f;
    public void MoveToPosition(Vector3 position, float time) {
        if(moveToCoroutine != null)
            StopCoroutine(moveToCoroutine);
        moveToCoroutine = MoveToPositionCoroutine(position, time);
        StartCoroutine(moveToCoroutine);
    }
    private IEnumerator MoveToPositionCoroutine(Vector3 position, float time) {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < time) {
            transform.position = Vector3.Lerp(startPosition, position, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(UpdateFrequency);
        }
        transform.position = position;
    }
}
