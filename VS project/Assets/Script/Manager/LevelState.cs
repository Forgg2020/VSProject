using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ToolManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    EnemyDataManager enemyDataManager;
    LevelDataManager levelDataManager;
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

    public float timer = 0;
    public delegate void OnLevelUpgrade();
    public event OnLevelUpgrade OnUpgrade;

    [Header("玩家升級")]
    public int SoulValue;
    void Start()
    {
        levelDataManager.EndPanel.SetActive(false);
        //FindObjectOfType<PlayerInteract>().OnPick += Healing;
        FindObjectOfType<EnemyInteract>().OnAtk += PlayerGetHurt;
        FindObjectOfType<EnemyInteract>().OnDead += DropItem;
        FindObjectOfType<PlayerInteract>().OnPick += CollectedSoul;
        FindObjectOfType<PlayerInteract>().OnPick += Healing;
    }
    public void AddEnemyToPool(GameObject enemy)
    {        
        EnemyPool.Add(enemy);
        EnemyInteract enemyInteract = enemy.GetComponent<EnemyInteract>();
        if (enemyInteract != null)
        {
            enemyInteract.OnAtk += PlayerGetHurt;
            SubscribeToOnDead(enemyInteract);
        }
    }
    private void SubscribeToOnDead(EnemyInteract enemyInteract)
    {
        enemyInteract.OnDead += DropItem;
    }
    public void DropItem(GameObject whichEnemydying)
    {
        dropRate = Random.Range(0, 10);
        if (dropRate > 1)
        {
            GameObject newItem = Instantiate(Item[1], whichEnemydying.transform.position, Quaternion.identity);
            newItem.transform.SetParent(null);
        }
        else if(dropRate == 1)
        {
            GameObject newItem = Instantiate(Item[0], whichEnemydying.transform.position, Quaternion.identity);
            newItem.transform.SetParent(null);
        }
        else if(dropRate == 0)
        {
            print("啥都不做");
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
            if (bloodbar.fillAmount > 0)
            {
                print("?" + Atk_percentage);
                canAtk = false;
                StartCoroutine(AttackPlayerCoroutine());
            }
            else if(bloodbar.fillAmount <= 0)
            {
                levelDataManager.EndPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void Healing(GameObject heal)
    {
        bloodbar.fillAmount += 0.1f;
    }

    public void CollectedSoul(GameObject whichItem)
    {
        if(whichItem.CompareTag("Soul"))
        {
            SoulValue = SoulValue +1;
        }
    }   

    private IEnumerator AttackPlayerCoroutine()
    {
        yield return new WaitForSeconds(2f);
        canAtk = true;
    }

    public void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10);
        timer += Time.deltaTime;
        if(timer > 30)
        {
            timer = 0;
            OnUpgrade?.Invoke();
        }
    }
    public void ReLoadScene()
    {
        SceneManager.LoadScene("NewScene");
        print("reload");
    }
}
