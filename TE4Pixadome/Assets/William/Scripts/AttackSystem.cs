using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackSystem : MonoBehaviour
{

    [SerializeField] GameObject autoAttack;
    [SerializeField] GameObject firstAbility;
    public Transform castPoint;
    
    MyInputManager myInputManager;
    GetTarget getTarget;
    NavMeshAgent agent;
    Stats stats;

    private void Awake()
    {
        myInputManager = new MyInputManager();
        getTarget = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<GetTarget>();
        getTarget.targetedObject = null;
        agent = gameObject.GetComponent<NavMeshAgent>();
        stats = gameObject.GetComponent<Stats>();

    }

    private void Update()
    {

        if (myInputManager.PlayerController.Attack.triggered)
        {
            //agent.stoppingDistance = stats.attackRange;

            AutoAttack();

        }

        if (myInputManager.PlayerController.FirstAbility.triggered)
        {
            FireFirstAbility();
        }

        //if (getTarget.targetedObject.transform.position - gameObject.transform.position <= stats.attackRange)
        //{

        //}

        if (getTarget.targetedObject == null)
        {
            agent.stoppingDistance = 0;
        }
    }

    void AutoAttack()
    {
        Instantiate(autoAttack, castPoint.transform.position, castPoint.rotation);
    }

    void FireFirstAbility()
    {
        Instantiate(firstAbility, castPoint.transform.position, castPoint.rotation);
    }



    private void OnEnable()
    {
        myInputManager.PlayerController.Enable();
        //myInputManager.PlayerMouse.Enable();

    }

    private void OnDisable()
    {
        myInputManager.PlayerController.Disable();
        //myInputManager.PlayerMouse.Disable();

    }
}
