using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public GameObject miniMapCorner;
    public GameObject miniMapCenter;

    MiniMapControlls minimapControlls;
    // Start is called before the first frame update
    void Awake()
    {
        minimapControlls = new MiniMapControlls();
        miniMapCenter.SetActive(false);

        minimapControlls.MiniMap.OpenMediumMapSize.performed += ctx => OpenMediumMap();
        minimapControlls.MiniMap.OpenMediumMapSize.canceled += ctx => CloseMediumMap();
    }

    void OpenMediumMap()
    {

        miniMapCenter.SetActive(true);
        miniMapCorner.SetActive(false);
    
    }

    void CloseMediumMap()
    {

        miniMapCenter.SetActive(false);
        miniMapCorner.SetActive(true);

    }

    private void OnEnable()
    {
        minimapControlls.MiniMap.Enable();
    }

    private void OnDisable()
    {
        minimapControlls.MiniMap.Disable();
    }
}
