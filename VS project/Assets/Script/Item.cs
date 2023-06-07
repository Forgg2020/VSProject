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
        FindObjectOfType<PlayerInteract>().OnPick += MoveToPlayer;
    }

    private void Update()
    {
        target = FindObjectOfType<PlayerInteract>().transform;
        targetPosition = target.transform.position;
        startPosition = transform.position;

    }
    protected void MoveToPlayer(GameObject colObj)
    {
        if (isMoving)
            return;
        StartCoroutine(SmoothMoveCoroutine(colObj));

        Destroy(gameObject);
    }
    protected IEnumerator SmoothMoveCoroutine(GameObject Item)
    {
        isMoving = true;
        float timer = 0f;

        Vector2 startPosition = transform.position;
        Vector2 targetPosition = target.position;

        while (timer < moveDuration)
        {
            timer += Time.deltaTime;

            float t = timer / moveDuration;

            Item.transform.position = Vector2.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        isMoving = false;
    }
}
