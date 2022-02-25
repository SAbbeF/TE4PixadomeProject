using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackSystem : MonoBehaviour
{

    [SerializeField] GameObject autoAttack;
    [SerializeField] GameObject firstAbility;
    [SerializeField] GameObject secondAbility;

    public Transform castPoint;
    
    MyInputManager myInputManager;
    NavMeshAgent agent;
    Stats stats;

    private void Awake()
    {
        myInputManager = new MyInputManager();
        agent = gameObject.GetComponent<NavMeshAgent>();
        stats = gameObject.GetComponent<Stats>();

    }

    private void Update()
    {

        if (myInputManager.PlayerController.Attack.triggered)
        {
            AutoAttack();
        }

        if (myInputManager.PlayerController.FirstAbility.triggered)
        {
            FireFirstAbility();
        }

        if (myInputManager.PlayerController.SecondAbility.triggered)
        {
            FireSecondAbility();
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

    void FireSecondAbility()
    {
        Instantiate(secondAbility, castPoint.transform.position, castPoint.rotation);
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
