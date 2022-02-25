using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour
{

    MyInputManager myInputManager;
    RaycastHit hit;
    public GameObject targetedObject;
    Camera thisCamera;


    private void Awake()
    {
        myInputManager = new MyInputManager();
        myInputManager.PlayerMouse.Move.performed += _ => GetTargetedObject();
        thisCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        //Debug.Log(targetedObject.GetComponent<CanBeTargeted>().typeOFObject);
    }

    public void GetTargetedObject()
    {

        if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)
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

        //myInputManager.PlayerMouse.Enable();

    }

    private void OnDisable()
    {

        //myInputManager.PlayerMouse.Disable();

    }
}
