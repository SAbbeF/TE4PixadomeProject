using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void QuitApplicationMethod()
    {

        Debug.Log("Quit");
        Application.Quit();

    }
}
