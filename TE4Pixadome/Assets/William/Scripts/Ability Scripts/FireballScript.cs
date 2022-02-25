using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : BaseAbility
{



    private void Update()
    {
        //transform.position = Vector3.Lerp(attackSystem.castPoint.position, cursorPosition, speed * Time.fixedDeltaTime);
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<HealthScript>() != null)
        {

        }

        if (other.CompareTag("Enemy"))
        {

            Destroy(this.gameObject);

        }

    }

}
