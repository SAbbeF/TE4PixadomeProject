using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementScript : MonoBehaviour
{
    //Vet ej hur jag ska reffera scriptet utan att använda mig av inspektorn
    MyInputManager myInputManager;  

    NavMeshAgent navMeshAgent;

    float rotateSpeed;
    float rotateVelocity;
    float rotationY;
    float maxDistance;

    Quaternion facingDirection;

    void Start()
    {

        rotateSpeed = 1f;
        maxDistance = Mathf.Infinity;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    
    void Awake()
    {
        myInputManager = new MyInputManager();
        myInputManager.Player.Move.performed += _ => MoveCharacter();

    }

    //private void Update()
    //{

    //    if (Input.GetMouseButtonDown(1))
    //    {

    //        MoveCharacter();

    //    }

    //}

    void MoveCharacter()
    {

        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, maxDistance))
        {
            //Move player to raycast hit location
            navMeshAgent.SetDestination(hitInfo.point);

            //Rotate character
            facingDirection = Quaternion.LookRotation(hitInfo.point - transform.position);

            rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                facingDirection.eulerAngles.y,
                ref rotateVelocity,
                rotateSpeed * (Time.deltaTime * 5));

            transform.eulerAngles = new Vector3(0, rotationY, 0);

            /*Mathf.SmoothDampAngle()

            1: current - Objects current posistion
            2: target - The posistion we are trying to reach
            3: currentVelocity - 
            4: smoothTime - Decides the speed it will take to reach targeted posistion
            */

        }

    }

    private void OnEnable()
    {

        myInputManager.Player.Enable();

    }

    private void OnDisable()
    {

        myInputManager.Player.Disable();
        //:)

    }
}
