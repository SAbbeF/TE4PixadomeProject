using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using Mirage;

public class PlayerMovementScript : NetworkBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    //Vet ej hur jag ska reffera scriptet utan att använda mig av inspektorn
    MyInputManager myInputManager;  
    NavMeshAgent navMeshAgent;
    Stats stats;
    public Camera playerCamera;

    float rotateSpeed;
    float rotateVelocity;
    float rotationY;
    float maxDistance;
    float smoothInputSpeed;
    Vector3 playerPosition;
    Vector2 input;
    Vector2 currentInput;
    Vector2 velocity;
    Quaternion facingDirection;

    //USED FOR ROTATION
    Ray ray;
    Plane plane;
    Vector3 cursorPosition;
    Vector3 direction;
    float rayDistance;
    float rotationAngle;


    void Start()
    {

        rotateSpeed = 1f;
        maxDistance = Mathf.Infinity;
        smoothInputSpeed = 0.2f;

        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        stats = gameObject.GetComponent<Stats>();

        playerCamera = GetComponentInChildren<Camera>();

        virtualCamera.gameObject.SetActive(true);
    }

    
    void Awake()
    {
        myInputManager = new MyInputManager();

        //myInputManager.PlayerMouse.Move.performed += _ => MoveCharacterWithMouse();

    }

    private void Update()
    {
        if (!IsLocalPlayer) return;
        
        MoveCharacterWithKeyboard();
        CaracterRotation();
    }

    void MoveCharacterWithKeyboard()
    {

        input = myInputManager.PlayerController.Move.ReadValue<Vector2>();
        currentInput = Vector2.SmoothDamp(currentInput, input, ref velocity, smoothInputSpeed);
        playerPosition = new Vector3(currentInput.x, 0, currentInput.y);
        transform.position += playerPosition * stats.movementSpeed * Time.fixedDeltaTime;

    }

    void CaracterRotation()
    {
        //cursorPosition = myInputManager.PlayerController.Rotation.ReadValue<Vector2>();

        ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        plane = new Plane(Vector3.up, Vector3.zero);
        
        if (plane.Raycast(ray, out rayDistance))
        {
            cursorPosition = ray.GetPoint(rayDistance);
            direction = cursorPosition - transform.position;
            rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotationAngle, 0);

        }
    }

    void MoveCharacterWithMouse()
    {
        
        RaycastHit hitInfo;

        if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, maxDistance))
        {
            //Move player to raycast hit location
            navMeshAgent.SetDestination(hitInfo.point);

            //Rotate character
            facingDirection = Quaternion.LookRotation(hitInfo.point - transform.position);

            rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                facingDirection.eulerAngles.y,
                ref rotateVelocity,
                rotateSpeed * (Time.deltaTime * 5));

            transform.eulerAngles = new Vector3(0, rotationY, 0);

            /*Mathf.SmoothDampAngle()

            1: current - Objects current posistion
            2: target - The posistion we are trying to reach
            3: currentVelocity - 
            4: smoothTime - Decides the speed it will take to reach targeted posistion
            */

        }

    }

    private void OnEnable()
    {
        myInputManager.PlayerController.Enable();
        //myInputManager.PlayerMouse.Enable();

    }

    private void OnDisable()
    {
        myInputManager.PlayerController.Disable();
        //myInputManager.PlayerMouse.Disable();

    }
}
