using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFollow : MonoBehaviour
{

    public GameObject target;
    public NavMeshAgent agent;
    GameObject playerTarget;

    public int goalRange;

    private void Update()
    {

        if (playerTarget != null)
        {

            agent.destination = playerTarget.transform.position;

        }
        else
        {

            float distance = Vector3.Distance(this.transform.position, target.transform.position);

            if (distance < goalRange)
            {
                agent.destination = target.transform.position;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            playerTarget = other.gameObject;

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {

            playerTarget = null;

        }

    }
}
