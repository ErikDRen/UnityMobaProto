using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] private Animator _anim;
    public float motionSmoothTime = .1f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        _anim.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);
    }
}
