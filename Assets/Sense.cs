using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sense : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Transform objectToChase;                                           // 추격할 위치
    public void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        objectToChase = GameObject.FindGameObjectWithTag("Player").transform;       // 추격할 위치:  Player 위치로 설정 
        if (_navMeshAgent == null)
            Debug.LogError("Nav Mesh Agent component not found attached to " + gameObject.name);
      
    }
    public void Update()
    {
        
        if (Vector3.Distance(transform.position, objectToChase.position) > 10f)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            _navMeshAgent.SetDestination(objectToChase.position);
        }
    }
}


