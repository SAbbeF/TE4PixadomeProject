using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BaseAbility : MonoBehaviour
{
    public float damageScale;
    public float speed;
    public float manaCost; //doesnt have to be mana could be other resources aswell :)
    public float lifeTime;
 
    protected AttackSystem attackSystem;
    protected GetTarget getTarget;
    protected SphereCollider mySphereCollider;
    protected Rigidbody myRigidbody;
    protected Camera playerCamera;



    protected void Awake()
    {

        //getTarget = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<GetTarget>();
        playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        attackSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackSystem>();

        mySphereCollider = GetComponent<SphereCollider>();
        mySphereCollider.isTrigger = true;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        if (lifeTime > 0)
        {
            Destroy(this.gameObject, lifeTime);
        }

    }

    private void Update()
    {


    }


}
