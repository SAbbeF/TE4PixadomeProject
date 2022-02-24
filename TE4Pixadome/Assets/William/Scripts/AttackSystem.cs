using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackSystem : MonoBehaviour
{

    [SerializeField] Ability autoAttack;
    public Transform castPoint;
    
    MyInputManager myInputManager;
    GetTarget getTarget;
    NavMeshAgent agent;
    Stats stats;

    private void Awake()
    {
        myInputManager = new MyInputManager();
        getTarget = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GetTarget>();
        getTarget.targetedObject = null;
        agent = gameObject.GetComponent<NavMeshAgent>();
        stats = gameObject.GetComponent<Stats>();
    }

    private void Update()
    {

        if (getTarget.targetedObject != null && getTarget.targetedObject.CompareTag("Enemy") && 
            myInputManager.Player.AutoAttack.triggered)
        {
            agent.stoppingDistance = stats.attackRange;

            AutoAttack();

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
        Debug.Log("Attacking");
        Instantiate(autoAttack, castPoint.transform.position, Quaternion.identity);

        //autoAttack.gameObject.transform.position = Vector3.Lerp(castPoint.transform.position, getTarget.targetedObject.transform.position, autoAttack.abilityToCast.speed * Time.fixedDeltaTime);

    }


    private void OnEnable()
    {
        myInputManager.Player.Enable();
    }

    private void OnDisable()
    {
        myInputManager.Player.Disable();
    }
}
