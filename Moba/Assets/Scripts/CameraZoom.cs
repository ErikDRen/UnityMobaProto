using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera _cam;
    private float camFOV;
    [SerializeField] private float zoomSpeed;
    private float mouseScrollInput;
    // Start is called before the first frame update
    void Start()
    {
        camFOV = _cam.fieldOfView;
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");
        camFOV -= mouseScrollInput * zoomSpeed;
        camFOV = Mathf.Clamp(camFOV, 30,70);

        _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, camFOV, zoomSpeed);
    }
}
