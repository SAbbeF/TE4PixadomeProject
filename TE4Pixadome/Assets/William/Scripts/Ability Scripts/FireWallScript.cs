using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallScript : BaseAbility
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthScript>() != null)
        {
            DealDamageOnCollision(other);
        }

        //if (other.CompareTag("Projectile"))
        //{
        //    Destroy(other);
        //}

    }
}
