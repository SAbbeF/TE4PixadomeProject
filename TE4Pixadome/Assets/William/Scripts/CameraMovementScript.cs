using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{

    float cameraSpeed;
    float boundary;
    int screenWidth;
    int screenHeight;

    Vector3 cameraPosition;
    Vector2 cameraLimit;

    float zoomSpeed;
    float maxY;
    float minY;

    // Start is called before the first frame update
    void Start()
    {

        cameraSpeed = 25;
        boundary = 50;
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        cameraLimit = new Vector2(20, 30);
        minY = 5;
        maxY = 25;
        zoomSpeed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = transform.position;

        if (Input.mousePosition.x > screenWidth - boundary)
        {

            cameraPosition.x += cameraSpeed * Time.deltaTime;
            

        }

        if (Input.mousePosition.x < boundary)
        {

            cameraPosition.x -= cameraSpeed * Time.deltaTime;
            
        }

        if (Input.mousePosition.y > screenHeight - boundary)
        {

            cameraPosition.z += cameraSpeed * Time.deltaTime;

        }

        if (Input.mousePosition.y < boundary)
        {

            cameraPosition.z -= cameraSpeed * Time.deltaTime;
        }

        //Make this using the new input system
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        cameraPosition.y -= scrollValue * zoomSpeed * 100f * Time.deltaTime;

        cameraPosition.x = Mathf.Clamp(cameraPosition.x, -cameraLimit.x, cameraLimit.x);
        cameraPosition.z = Mathf.Clamp(cameraPosition.z, -cameraLimit.y, cameraLimit.y);

        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY, maxY);

        transform.position = cameraPosition;

    }

    //void OnGUI()
    //{
    //    GUI.Box(Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
    //    GUI.Box(Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
    //    GUI.Box(Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);
    //}

}
