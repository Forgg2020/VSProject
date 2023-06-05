using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    EnemyDataManager enemyDataManager;
    public List<GameObject> EnemyPool;
    FindObj FindObj = new FindObj();
    public Image bloodbar;
    public int HowManyEnemyDead;
    //Item
    public Transform target;
    public float moveDuration = 0.5f;
    public bool isMoving;

    public delegate void OnLevelUpgrade();
    public event OnLevelUpgrade OnUpgrade;
    void Start()
    {
        //FindObjectOfType<PlayerInteract>().OnPick += Healing;
        FindObjectOfType<EnemyInteract>().OnAtk += PlayerGetHurt;
        FindObjectOfType<PlayerInteract>().OnPick += MoveToPlayer;
    }
    public void AddEnemyToPool(GameObject enemy)
    {        
        EnemyPool.Add(enemy);
        EnemyInteract enemyInteract = enemy.GetComponent<EnemyInteract>();
        if (enemyInteract != null)
        {
            enemyInteract.OnAtk += PlayerGetHurt;
            enemyInteract.OnDead += ConflictUpgrade;
        }
    }

    public void RemoveEnemyToPool(GameObject enemy)
    {
        EnemyPool.Remove(enemy);
    }
    public void PlayerGetHurt(float atkvalue)
    {
        var Atk_percentage = atkvalue / 100;
        bloodbar.fillAmount -= Atk_percentage;
        print(Atk_percentage);
    }

    public void Healing()
    {
        bloodbar.fillAmount += 0.1f;
    }

    public void ConflictUpgrade()
    {
        HowManyEnemyDead = HowManyEnemyDead + 1;
        if(HowManyEnemyDead >= 10)
        {
            OnUpgrade?.Invoke();
        }
        else if(HowManyEnemyDead >=25)
        {
            OnUpgrade?.Invoke();
        }
        else if(HowManyEnemyDead >=50)
        {
            OnUpgrade?.Invoke();
        }
        else if (HowManyEnemyDead >= 75)
        {
            OnUpgrade?.Invoke();
        }
        else if (HowManyEnemyDead >= 100)
        {
            OnUpgrade?.Invoke();
        }
        else if (HowManyEnemyDead >= 125)
        {
            OnUpgrade?.Invoke();
        }
    }

    protected void MoveToPlayer(GameObject colObj)
    {
        if (isMoving)
            return;
        StartCoroutine(SmoothMoveCoroutine(colObj));
    }
    protected IEnumerator SmoothMoveCoroutine(GameObject Item)
    {
        isMoving = true;
        float timer = 0f;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = target.position;

        while (timer < moveDuration)
        {
            timer += Time.deltaTime;

            float t = timer / moveDuration;

            Item.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }
        Destroy(Item);
        isMoving = false;
    }
}
