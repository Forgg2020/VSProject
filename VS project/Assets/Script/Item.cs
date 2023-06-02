using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform target;
    public float moveDuration = 0.5f;
    void Start()
    {
        FindObjectOfType<PlayerInteract>().OnPick += MoveToPlayer;
    }
    private void Update()
    {
        target = FindObjectOfType<PlayerInteract>().transform;
    }
    public void MoveToPlayer()
    {
        StartCoroutine(SmoothMoveCoroutine());
    }
    private IEnumerator SmoothMoveCoroutine()
    {
        float timer = 0f;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = target.position;

        while (timer < moveDuration)
        {
            timer += Time.deltaTime;

            float t = timer / moveDuration;

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }
        Destroy(gameObject);
    }

}
