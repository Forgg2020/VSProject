using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform target;
    public float moveDuration = 0.5f;
    public bool isMoving;
    public Vector3 targetPosition;
    private void Update()
    {
        target = FindObjectOfType<PlayerInteract>().transform;
        targetPosition = target.transform.position;
    }
    protected void MoveToPlayer()
    {
        if (isMoving)
            return;
        StartCoroutine(SmoothMoveCoroutine());
    }
    protected IEnumerator SmoothMoveCoroutine()
    {
        isMoving = true;
        float timer = 0f;

        Vector3 startPosition = gameObject.transform.position;

        while (timer < moveDuration)
        {
            timer += Time.deltaTime;

            float t = timer / moveDuration;

            gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }
        gameObject.SetActive(false);
        isMoving = false;
    }
}
