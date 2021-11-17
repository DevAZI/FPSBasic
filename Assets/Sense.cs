using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sense : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Transform objectToChase;                                           // �߰��� ��ġ
    public void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        objectToChase = GameObject.FindGameObjectWithTag("Player").transform;       // �߰��� ��ġ:  Player ��ġ�� ���� 
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


