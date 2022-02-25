using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFollow : MonoBehaviour
{

    public GameObject target;
    public NavMeshAgent agent;
    public GameObject playerTarget;
    public attackRange attackRange;
    GameObject[] enemiesInsideAttackRange;

    public float lookAtEnmenySpeed;
    float distanceToGoal;
    public int goalRange;
    bool isBeingAttacked;
    int arrayPostition;

    Quaternion rotation;
    private void Start()
    {
        enemiesInsideAttackRange = new GameObject[10];
        arrayPostition = 0;
    }

    private void Update()
    {
        //attack behöver fixas in.
        //Det bör fixas prioritering på attacker alltså blir du attackerad av en spelare spring efter den.

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
            //endast en attack eller många?
            //timer coldown på attacker här eller i attack script
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

    //bör fixa så att när den attackerar en fiende så kommer den inte att sticka iväg efter någon annan innan den dödat fienden
    //ska vi ha egna minion? annars funkar nog koden. ifall vi ska ha minions så bör vi prioritera minion attacks eller player attacks
    private void OnTriggerEnter(Collider other)
    {
        bool alreadyAdded = false;
        if (other.tag == "Player")
        {
            if (playerTarget == null)
            {
                
                playerTarget = other.gameObject;

            }
            else
            {
                for (int i = 0; i < enemiesInsideAttackRange.Length; i++)
                {

                    if (other.gameObject == enemiesInsideAttackRange[i])
                    {
                        alreadyAdded = true;
                    }
                    
                }

                if (!alreadyAdded)
                {

                    enemiesInsideAttackRange[arrayPostition] = other.gameObject;
                    alreadyAdded = false;

                    if (arrayPostition == 9)
                    {
                        arrayPostition = 0;
                    }

                }

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        bool hasValue = false;
        GameObject smallestDistanceBetween = null;

        if (other.tag == "Player")
        {
            if (playerTarget.gameObject == other.gameObject)
            {

                playerTarget = null;

                for (int i = 0; i < enemiesInsideAttackRange.Length; i++)
                {

                    if (enemiesInsideAttackRange[i] != null)
                    {

                        hasValue = true;
                        i = enemiesInsideAttackRange.Length;
                    }

                }

                if (hasValue)
                {
                    
                    for (int i = 0; i < enemiesInsideAttackRange.Length; i++)
                    {
                        if (enemiesInsideAttackRange[i] != null)
                        {

                            if (smallestDistanceBetween == null)
                            {
                                smallestDistanceBetween = enemiesInsideAttackRange[i];
                            }
                            else
                            {
                                if (Vector3.Distance(smallestDistanceBetween.transform.position, agent.transform.position) > Vector3.Distance(enemiesInsideAttackRange[i].transform.position, agent.transform.position))
                                {
                                    smallestDistanceBetween = enemiesInsideAttackRange[i];
                                }
                            }

                        }


                    }

                    playerTarget = smallestDistanceBetween;

                    hasValue = false;
                }
            }
            else
            {
                for (int i = 0; i < enemiesInsideAttackRange.Length; i++)
                {
                    if (other.gameObject == enemiesInsideAttackRange[i])
                    {
                        enemiesInsideAttackRange[i] = null;
                    }
                }
            }

        }

    }

}
