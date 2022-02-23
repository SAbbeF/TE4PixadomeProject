using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ability : MonoBehaviour
{

    public AttackScriptableObject abilityToCast;

    GetTarget getTarget;
    GameObject player;
    SphereCollider mySphereCollider;
    Rigidbody myRigidbody;

    private void Awake()
    {
        getTarget = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GetTarget>();
        player = GameObject.FindGameObjectWithTag("Player");

        mySphereCollider = GetComponent<SphereCollider>();
        mySphereCollider.isTrigger = true;
        mySphereCollider.radius = abilityToCast.abilitySize;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;
    }

    private void Update()
    {

        if (abilityToCast.followTarget && getTarget.targetedObject != null)
        {
            transform.position = Vector3.Lerp(player.transform.position, getTarget.targetedObject.transform.position, abilityToCast.speed * Time.fixedDeltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        //Apply spell affect

        if (other != this.gameObject && abilityToCast.destroyOnCollision)
        { 
            Destroy(this.gameObject);
        }

    }

}
