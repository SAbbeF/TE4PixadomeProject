using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackRange : MonoBehaviour
{

    public bool isWithinAttackRange;
    public GameObject target;
    public AiFollow aiFollow;
    public UnityEngine.AI.NavMeshAgent agent;
    public bool canOnlyAttackFollowedTarget;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (!canOnlyAttackFollowedTarget)
            {

                if (target == null)
                {

                    isWithinAttackRange = true;
                    target = other.gameObject;

                }

            }
            else if(other.gameObject == aiFollow.playerTarget.gameObject)
            {

                isWithinAttackRange = true;
                target = other.gameObject;

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            if (target.gameObject == other.gameObject)
            {

                isWithinAttackRange = false;
                target = null;
            
            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && target == null)
        {

            isWithinAttackRange = true;
            target = other.gameObject;
            //s�tta in allt som r�r i den i en array
            //cehcka igenom arrayen vilken som �r n�rmast
            //s�tt den till targetplayer
        }
    }
}
