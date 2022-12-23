using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    [SerializeField] private GameObject selectdHero;
    [SerializeField] private bool heroPlayer;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        selectdHero = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //Minion Target
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //If Minion is targetable
                if (hit.collider.GetComponent<Targetable>() != null)
                {
                    if (hit.collider.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                    {
                        selectdHero.GetComponent<HeroCombat>().targetedEnemy = hit.collider.gameObject;
                    }
                }

                else if(hit.collider.GetComponent<Targetable>() == null)
                {
                    selectdHero.GetComponent<HeroCombat>().targetedEnemy = null;
                }
            }
        }



    }
}
