using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFollow : MonoBehaviour
{

    public GameObject target;
    public NavMeshAgent agent;
    GameObject playerTarget;
    public attackRange attackRange;

    public float lookAtEnmenySpeed;
    float distanceToGoal;
    public int goalRange;
    bool isBeingAttacked;

    Quaternion rotation;

    private void Update()
    {

        if (playerTarget != null && !attackRange.isWithinAttackRange && distanceToGoal > 3)
        {

            agent.destination = playerTarget.transform.position;

             Vector3.Distance(agent.transform.position, playerTarget.transform.position);

        }
        else if (attackRange.isWithinAttackRange && distanceToGoal > 3)
        {
            if (agent.destination != agent.transform.position)
            {
                
                agent.destination = agent.transform.position;

            }

            rotation = Quaternion.LookRotation(attackRange.target.transform.position - agent.transform.position);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotation, Time.deltaTime  * lookAtEnmenySpeed);

            //insert attack
            //endast en attack eller m�nga?
            //timer coldown p� attacker h�r eller i attack script
        }
        else
        {

            distanceToGoal = Vector3.Distance(this.transform.position, target.transform.position);

            if (distanceToGoal < goalRange)
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
            if (playerTarget == null)
            {
                
                playerTarget = other.gameObject;

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            if (playerTarget.gameObject == other.gameObject)
            {

                playerTarget = null;
            
            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && playerTarget == null)
        {
            //s�tta in allt som r�r i den i en array
            //cehcka igenom arrayen vilken som �r n�rmast
            //s�tt den till targetplayer
        }
    }
}
