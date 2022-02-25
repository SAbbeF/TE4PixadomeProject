using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutoAttack : BaseAbility
{



    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {

            Destroy(this.gameObject);

        }

    }
}
