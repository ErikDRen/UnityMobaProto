using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoam : MonoBehaviour
{

    [SerializeField] float camSpeed = 20;
    [SerializeField] float screenSizeThickness = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        //Up
        if (Input.mousePosition.y >= Screen.height - screenSizeThickness)
            pos.z += camSpeed * Time.deltaTime;

        //Down
        if (Input.mousePosition.y <= screenSizeThickness)
            pos.z -= camSpeed * Time.deltaTime;


        //Right
        if (Input.mousePosition.x >= Screen.height - screenSizeThickness)
            pos.x += camSpeed * Time.deltaTime;

        //Left
        if (Input.mousePosition.x <= screenSizeThickness)
            pos.x -= camSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
