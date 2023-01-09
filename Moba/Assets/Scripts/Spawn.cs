using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    GameObject grongron;
    public int nbMonster = 1;
    [SerializeField] GameObject gg;

    void Start()
    {
        grongron = GameObject.FindGameObjectWithTag("Enemy");
    }



    private void Update()
    {
        if(grongron == null && nbMonster > 0)
        {
            SpawnMonster();
            nbMonster--;
        }

        if (nbMonster == 0)
        {
            gg.SetActive(true);
        }
    }


    public void SpawnMonster()
    {
        Vector3 pos = new Vector3(0f, 0f, 0f);
        Instantiate(spawnPrefab, pos, Quaternion.identity);
        grongron = GameObject.FindGameObjectWithTag("Enemy");
    }
}
