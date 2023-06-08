using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    PlayerDataManager playerDataManager;

    private void Start()
    {
        playerDataManager = GameObject.Find("Player").GetComponent<PlayerDataManager>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            print("Move");
            StartCoroutine(MoveToPlayer());

        }
    }

    public IEnumerator MoveToPlayer()
    {
        while (true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerDataManager.Player_Transform.position, 10f * Time.deltaTime);
            
            yield return null;
            Invoke("OnDestroy", 0.5f);
        }
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
