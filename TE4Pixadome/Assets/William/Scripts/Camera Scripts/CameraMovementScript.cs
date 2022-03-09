using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{

    float cameraSpeed;
    float boundary;
    int screenWidth;
    int screenHeight;
    float zoomSpeed;
    float maxY;
    float minY;
    bool isCameraLocked;
    bool isCameraFollowing;
    Vector3 cameraPosition;
    Vector2 cameraLimit;
    Vector3 lockCameraRotation;
    Quaternion rotation;

    GameObject player;
    MyInputManager myInputManager;

    // Start is called before the first frame update
    void Start()
    {

        cameraSpeed = 25;
        boundary = 50;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        cameraLimit = new Vector2(20, 30);
        lockCameraRotation = new Vector3(0, 0, 0);
        minY = 5;
        maxY = 20;
        zoomSpeed = 30;
        isCameraLocked = true;
        isCameraFollowing = false;

        player = transform.parent.gameObject;
    }

    void Awake()
    {
        myInputManager = new MyInputManager();
        //myInputManager.Camera.LockCamera.performed += _ => SetCameraFlag();

    }

    void Update()
    {
            cameraPosition = transform.position;

            if (Input.GetKeyDown(KeyCode.Y))
            {
                isCameraLocked = !isCameraLocked;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isCameraFollowing = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isCameraFollowing = false;
            }

            if (isCameraLocked || isCameraFollowing)
            {
                CameraFollowPlayer();
            }
            else
            {
                CameraPanMovement();
            }

            CameraZoom();

            transform.position = cameraPosition;
    }

    void CameraPanMovement()
    {


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

        cameraPosition.x = Mathf.Clamp(cameraPosition.x, -cameraLimit.x, cameraLimit.x);
        cameraPosition.z = Mathf.Clamp(cameraPosition.z, -cameraLimit.y, cameraLimit.y);
        

    }

    void CameraFollowPlayer()
    {

        cameraPosition.x = player.transform.position.x;
        cameraPosition.z = player.transform.position.z - 8;
    }

    void CameraZoom()
    {

        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        cameraPosition.y -= scrollValue * zoomSpeed * 100f * Time.deltaTime;
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY, maxY);
    }

    void SetCameraFlag()
    {

        isCameraLocked = !isCameraLocked;

    }

    //private void OnEnable()
    //{

    //    myInputManager.Camera.Enable();

    //}

    //private void OnDisable()
    //{

    //    myInputManager.Camera.Disable();

    //}

}
