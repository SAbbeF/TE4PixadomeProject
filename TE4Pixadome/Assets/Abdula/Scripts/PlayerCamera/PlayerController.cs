using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using Mirage;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private Transform playerTransform;

    private CinemachineTransposer transposer;

    private NavMeshAgent navMeshAgent;

    private Stats stats;

    private MyInputManager inputManager;
    private MyInputManager InputManager
    {
        get
        {
            if (inputManager != null) { return inputManager; };
            return inputManager = new MyInputManager();
        }
    }

    private float smoothInputSpeed;
    private Vector3 playerPosition;
    private Vector2 input;
    private Vector2 currentInput;
    private Vector2 velocity;
    private Quaternion facingDirection;

    Ray ray;
    Plane plane;
    Vector3 cursorPosition;
    Vector3 direction;
    float rayDistance;
    float rotationAngle;

    PlayerController()
    {
        virtualCamera = null;
        playerTransform = null;

        smoothInputSpeed = 0.2f;
    }

    private void Awake()
    {
        Identity.OnAuthorityChanged.AddListener(OnStartAuthority);
    }

    private void Update()
    {
        if (IsLocalPlayer)
        {
            MoveCharacterWithKeyboard();
        }
    }

    private void OnStartAuthority(bool changed)
    {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        
        stats = gameObject.GetComponent<Stats>();

        virtualCamera.gameObject.SetActive(true);

        enabled = true;

        //InputManager.PlayerController.Move.performed += ctx => MoveCharacterWithKeyboard(ctx.ReadValue<Vector2>());
    }

    private void MoveCharacterWithKeyboard()
    {
        input = InputManager.PlayerController.Move.ReadValue<Vector2>();
        currentInput = Vector2.SmoothDamp(currentInput, input, ref velocity, smoothInputSpeed);
        playerPosition = new Vector3(currentInput.x, 0, currentInput.y);
        transform.position += playerPosition * stats.movementSpeed * Time.fixedDeltaTime;
    }

    private void CharacterRotation()
    {
        //ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out rayDistance))
        {
            cursorPosition = ray.GetPoint(rayDistance);
            direction = cursorPosition - transform.position;
            rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotationAngle, 0);

        }
    }

    [Client(error = false)]
    private void OnEnable() => InputManager.Enable();

    [Client(error = false)]
    private void OnDisable() => InputManager.Disable();
}
