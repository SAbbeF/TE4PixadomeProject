using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackRange : MonoBehaviour
{

    public bool isWithinAttackRange;
    public GameObject target;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (target == null)
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
