using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFollow : MonoBehaviour
{

    public GameObject target;
    public NavMeshAgent agent;
    GameObject playerTarget;
    //Transform oldPosition;

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

    //b�r fixa s� att n�r den attackerar en fiende s� kommer den inte att sticka iv�g efter n�gon annan innan den d�dat fienden
    //ska vi ha egna minion? annars funkar nog koden. ifall vi ska ha minions s� b�r vi prioritera minion attacks eller player attacks
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
