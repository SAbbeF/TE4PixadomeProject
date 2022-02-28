using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject MenuToStart;
    bool menuActive;

    public EscapeToMenu()
    {



    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (menuActive == true)
            {

                stopMenu();

            }

            else
            {

                StartMenu();

            }

        }

    }

    void stopMenu()
    {


        MenuToStart.SetActive(false);


    }
    void StartMenu()
    {


        MenuToStart.SetActive(true);


    }

}
