using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    CinemachineComponentBase ComponentBase;

    float scrollValue;
    [SerializeField] float sensivity;
    [SerializeField] int minZoom;
    [SerializeField] int maxZoom;
    private void Awake()
    {
        //virtualCamera = GetComponent<CinemachineVirtualCamera>();
        ComponentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }

    void Update()
    {
        scrollValue = Input.GetAxis("Mouse ScrollWheel");
        scrollValue = Mathf.Clamp(scrollValue, minZoom, maxZoom);
        (ComponentBase as CinemachineFramingTransposer).m_CameraDistance -= scrollValue * sensivity * Time.fixedDeltaTime;

    }
}
