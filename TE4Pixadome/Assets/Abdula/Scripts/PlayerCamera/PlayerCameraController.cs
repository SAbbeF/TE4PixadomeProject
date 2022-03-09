using Cinemachine;
using UnityEngine;
using Mirage;

public class PlayerCameraController : NetworkBehaviour
{
    [Header("Camera")]
    [SerializeField]
    private Vector2 maxFollowOffSet;

    [SerializeField]
    private Vector2 cameraVelocity;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    private CinemachineTransposer transposer;

    private MyInputManager inputManager;
    
    private MyInputManager InputManager
    {
        get
        {
            if (inputManager != null) { return inputManager; };
            return inputManager = new MyInputManager();
        }
    }

    PlayerCameraController()
    {
        maxFollowOffSet = new Vector2(-1f, 6f);
        cameraVelocity = new Vector2(4f, 0.25f);
        playerTransform = null;
        virtualCamera = null;
    }

    private void Awake()
    {
        Identity.OnAuthorityChanged.AddListener(OnStartAuthority);
    }

    private void OnStartAuthority(bool changed)
    {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        virtualCamera.gameObject.SetActive(true);

        enabled = true;

        //InputManager.PlayerController.Move.performed +=
    }

    [Client(error = false)]
    private void OnEnable() => InputManager.Enable();

    [Client(error = false)]
    private void OnDisable() => InputManager.Disable();
}
