using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosionScript : BaseAbility
{

    float durationUntilExplosion = 10;
    float timer = 0;
    Vector3 explosionSize = new Vector3(50, 50, 50);

    private void Update()
    {
        timer += Time.fixedDeltaTime;

        if (timer < durationUntilExplosion)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }

        if (timer >= durationUntilExplosion)
        {
            transform.localScale = explosionSize;
        }

    }



}
