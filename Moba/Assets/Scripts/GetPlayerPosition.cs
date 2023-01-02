using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerPosition : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject forward;

    private void Update()
    {
        forward.transform.position = player.transform.position;
    }
}
