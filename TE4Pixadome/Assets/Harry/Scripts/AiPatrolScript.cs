using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiPatrolScript : MonoBehaviour
{
    public Transform[] wayPoints;
    public AiFollow aiFollow;
    public NavMeshAgent agent;

    public int speed;

    public int wayPointIndex;
    private float distance;
    bool walkBackDistance;

    void Start()
    {

        walkBackDistance = false;
        wayPointIndex = 0;
        transform.LookAt(wayPoints[wayPointIndex].position);

    }

    // Update is called once per frame
    void Update()
    {
        //if satsa allt detta och ifall fiende är inom range gå och attackera men bara ifall distancen från waypoint är inte för lång
        //isåfall aktivera patrol script och att man inte kan attackera  player till man gått tillbaka
        //öka även walk speeden detta gör det svårare att bara attackera och sedan springa till den ska gå tillbaka

        distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);

        if (distance < 1)
        {

            IncreaseIndex();

        }

        if (distance > 40)
        {
            walkBackDistance = true;
        }

        if (aiFollow.playerTarget == null || walkBackDistance)
        {

            Patrol();
        
        }
    }

    void Patrol()
    {

        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        agent.destination = wayPoints[wayPointIndex].position;

    }

    void IncreaseIndex()
    {

        wayPointIndex++;
        if (wayPointIndex >= wayPoints.Length)
        {
            wayPointIndex = 0;
        }

        transform.LookAt(wayPoints[wayPointIndex].position);

        walkBackDistance = false;
    }
}
