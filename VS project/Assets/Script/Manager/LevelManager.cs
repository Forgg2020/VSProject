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
    [Header("掉落")]
    public Transform target;
    public float moveDuration = 0.5f;
    public bool isMoving;
    public bool canAtk = true;
    public GameObject[] Item;
    public int dropRate;
    //Camera
    public GameObject Camera;
    public float speed = 2f;
    public delegate void OnLevelUpgrade();
    public event OnLevelUpgrade OnUpgrade;

    [Header("玩家升級")]
    public int SoulValue;
    void Start()
    {
        //FindObjectOfType<PlayerInteract>().OnPick += Healing;
        FindObjectOfType<EnemyInteract>().OnAtk += PlayerGetHurt;
        FindObjectOfType<EnemyInteract>().OnDead += DropItem;
    }
    public void AddEnemyToPool(GameObject enemy)
    {        
        EnemyPool.Add(enemy);
        EnemyInteract enemyInteract = enemy.GetComponent<EnemyInteract>();
        if (enemyInteract != null)
        {
            enemyInteract.OnAtk += PlayerGetHurt;
            enemyInteract.OnDead += ConflictUpgrade;
            SubscribeToOnDead(enemyInteract);
        }
    }
    private void SubscribeToOnDead(EnemyInteract enemyInteract)
    {
        enemyInteract.OnDead += DropItem;
    }
    public void DropItem(GameObject whichEnemydying)
    {
        print("知道了");
        int i;
        dropRate = Random.Range(0, 2);
        if (dropRate == 0)
        {
            i = Random.Range(0, 2);
            GameObject newItem = Instantiate(Item[i], whichEnemydying.transform.position, Quaternion.identity);
            newItem.transform.SetParent(null);
        }
    }

    public void RemoveEnemyToPool(GameObject enemy)
    {
        EnemyPool.Remove(enemy);
    }
    public void PlayerGetHurt(float atkvalue)
    {
        if (canAtk == true)
        {
            var Atk_percentage = atkvalue / 100;
            bloodbar.fillAmount -= Atk_percentage;
            print("?" + Atk_percentage);
            canAtk = false;
            StartCoroutine(AttackPlayerCoroutine());
        }
    }
    public void Healing()
    {
        bloodbar.fillAmount += 0.1f;
    }

    public void CollectedSoul()
    {

    }

    public void ConflictUpgrade(GameObject whichenemy)
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

    

    private IEnumerator AttackPlayerCoroutine()
    {
        yield return new WaitForSeconds(2f);
        canAtk = true;
    }

    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10);
    }

}
