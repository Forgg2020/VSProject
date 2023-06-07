using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ToolManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public event OnLevelUpgrade OnUpgrade02;
    public event OnLevelUpgrade OnUpgrade03;
    public event OnLevelUpgrade OnUpgrade04;

    [Header("玩家升級")]
    public int SoulValue;
    public float timer;
    public GameObject UpgradePanel;
    public GameObject EndPanel;
    void Start()
    {
        EndPanel.SetActive(false);
        //FindObjectOfType<PlayerInteract>().OnPick += Healing;
        FindObjectOfType<EnemyInteract>().OnAtk += PlayerGetHurt;
        FindObjectOfType<EnemyInteract>().OnDead += DropItem;
        FindObjectOfType<PlayerInteract>().OnPick += CollectedSoul;
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
                EndPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void Healing()
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

    public void ConflictUpgrade(GameObject whichenemy)
    {
        //HowManyEnemyDead = HowManyEnemyDead + 1;
        //if(HowManyEnemyDead >= 10)
        //{
        //    print("L1");
        //    OnUpgrade?.Invoke();
        //}
        //else if(HowManyEnemyDead >=15)
        //{
        //    print("L2");
        //    OnUpgrade02?.Invoke();
        //}
        //else if(HowManyEnemyDead >=50)
        //{
        //    print("L3");
        //    OnUpgrade03?.Invoke();
        //}
        //else if (HowManyEnemyDead >= 75)
        //{
        //    print("L4");
        //    OnUpgrade04?.Invoke();
        //}
    }

    

    private IEnumerator AttackPlayerCoroutine()
    {
        yield return new WaitForSeconds(2f);
        canAtk = true;
    }

    public  void Update()
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
