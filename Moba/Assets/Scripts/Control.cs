using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] GameObject particles;

    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //On
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            particles.SetActive(true);
            particles.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        }
        //OFf
        if(Input.GetMouseButtonUp(0))
        {
            particles.SetActive(false);
        }
    }
}
