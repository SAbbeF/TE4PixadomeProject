using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ability : MonoBehaviour
{

    public AttackScriptableObject abilityToCast;

    SphereCollider mySphereCollider;
    Rigidbody myRigidbody;


    private void Awake()
    {

        mySphereCollider = GetComponent<SphereCollider>();
        mySphereCollider.isTrigger = true;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        if (abilityToCast.lifeTime > 0)
        {
            Destroy(this.gameObject, abilityToCast.lifeTime);
        }
    }

    private void Update()
    {





    }

    private void OnTriggerEnter(Collider other)
    {



    }

}
