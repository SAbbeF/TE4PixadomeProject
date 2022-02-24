using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour
{

    MyInputManager myInputManager;
    RaycastHit hit;
    public GameObject targetedObject;


    private void Awake()
    {
        myInputManager = new MyInputManager();
        myInputManager.Player.Move.performed += _ => GetTargetedObject();

    }

    private void Update()
    {
        //Debug.Log(targetedObject.GetComponent<CanBeTargeted>().typeOFObject);
    }

    public void GetTargetedObject()
    {

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)
            && hit.collider.GetComponent<CanBeTargeted>() != null)
        {

            targetedObject = hit.collider.gameObject;

        }
        else
        {
            targetedObject = null;
        }
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
