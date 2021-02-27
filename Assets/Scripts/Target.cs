using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    NavMeshAgent m_nma;

    // Start is called before the first frame update
    void Start()
    {
        m_nma = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        m_nma.SetDestination(GameObject.FindWithTag("Player").transform.position);
        
    }
}
