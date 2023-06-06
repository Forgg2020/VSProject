using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform target;
    public float moveDuration = 0.5f;
    public bool isMoving;
    public Vector3 targetPosition;
    public Vector3 startPosition;
    private void Start()
    {
        startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        target = FindObjectOfType<PlayerInteract>().transform;
        targetPosition = target.transform.position;
        startPosition = transform.position;

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
