using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveSizeShower : MonoBehaviour
{
    public GameObject vfxShockWave;
    public GameObject getAnimatorFrom;

    Animator anim;
    private void Awake()
    {
        vfxShockWave.SetActive(false);
        anim = getAnimatorFrom.GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetBool("SpecialAttack") == true)
        {
            vfxShockWave.SetActive(true);

            //rotate around
            vfxShockWave.transform.RotateAround(gameObject.transform.position, Vector3.right, 90);

            //vfxShockWave.SetActive(false);
        }
    }
}
