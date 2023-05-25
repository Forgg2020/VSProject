using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weaponObjects = new List<GameObject>();
    public static WeaponManager Instance;
    FindObj FindObj = new FindObj();
    public GameObject[] weapon;
    public GameObject Wp;
    public float timer = 4;


    private void Start()
    {
        weapon = FindObj.FindObjectsbyTag("Enemy");
    }
    private void Update()
    {

    }
    void ShowWeapon(float CD)
    {
        for(int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(true);
        }
    }
}
