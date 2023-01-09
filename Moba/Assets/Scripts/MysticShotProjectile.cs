using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticShotProjectile : MonoBehaviour
{
    public float damage;

    public float speed;


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyObject());

        gameObject.transform.TransformDirection(Vector3.forward);
        gameObject.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}