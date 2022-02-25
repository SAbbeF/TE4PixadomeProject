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
    Vector3 mousePosition;

    private void Awake()
    {
        getTarget = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GetTarget>();
        player = GameObject.FindGameObjectWithTag("Player");

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

        mousePosition = Input.mousePosition;
        //mousePosition.y = 0;

        if (abilityToCast.followTarget && getTarget.targetedObject != null)
        {
            transform.position = Vector3.Lerp(getTarget.targetedObject.transform.position, player.transform.position, abilityToCast.speed * Time.fixedDeltaTime);
        }

        if (abilityToCast.isSkillshot)
        {
            transform.Translate(Vector3.forward * abilityToCast.speed * Time.fixedDeltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        //Apply spell affect

        if (other != this.gameObject && other.tag != "Player")
        { 
            Destroy(this.gameObject);
        }

    }

}
