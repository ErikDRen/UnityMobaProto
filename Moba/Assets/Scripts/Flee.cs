using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    [SerializeField] Transform target;
    GameObject grongron;

    // Start is called before the first frame update
    void Start()
    {
        grongron = GameObject.FindGameObjectWithTag("Enemy");
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - target.position;

        if(direction.sqrMagnitude < 25f)
        {
            if (grongron != null)
            {
                grongron.GetComponent<Animator>().SetBool("isRun", true);
            }
            transform.Translate(direction.normalized * Time.deltaTime, Space.World);
            transform.forward = direction.normalized;
        } else
        {
            if (grongron != null)
            {
                grongron.GetComponent<Animator>().SetBool("isRun", false);
            }
        }

    }
}
