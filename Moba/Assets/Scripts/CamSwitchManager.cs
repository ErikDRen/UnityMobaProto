using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitchManager : MonoBehaviour
{

    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] CameraRoam cameraRoam;

    bool camViewChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraRoam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(camViewChanged == false)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                camViewChanged = true;
                cameraRoam.enabled = true;
                cameraFollow.enabled = false;
            }
        } else if (camViewChanged == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                camViewChanged= false;
                cameraRoam.enabled = false;
                cameraFollow.enabled = true;
            }
        }
    }
}
