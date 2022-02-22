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

            isWithinAttackRange = true;
            target = other.gameObject;

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {

            isWithinAttackRange = false;
            target = null;

        }

    }
}
