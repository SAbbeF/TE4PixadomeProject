//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/William/Scripts/MyInputManager.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MyInputManager : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyInputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInputManager"",
    ""maps"": [
        {
            ""name"": ""PlayerMouse"",
            ""id"": ""cb96f5bc-faa4-4791-91c1-e9440d5a20d3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""72a2a6f7-2dc1-4531-9b8c-74e6e3d86b1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AutoAttack"",
                    ""type"": ""Button"",
                    ""id"": ""5a1f12c9-4701-4187-b98d-651796e58cc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FirstAbility"",
                    ""type"": ""Button"",
                    ""id"": ""a23ae3b9-9c40-4912-b079-bb1952aa4d4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5ec47f08-5f45-419c-b24a-5dabe8c82f6e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fead14d-0e70-4dab-9db9-67d13b6653fe"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""AutoAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf53795c-ab9f-4038-bfa6-7b8eca94f1df"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""c128379a-6a7f-4c95-8d63-dde0e653d5fc"",
            ""actions"": [
                {
                    ""name"": ""LockCamera"",
                    ""type"": ""Button"",
                    ""id"": ""659a984c-e1b4-41f0-99be-1060d1b52b6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""28e0fc1c-8e5b-41e0-afb9-1a13cc01ec48"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""LockCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerController"",
            ""id"": ""8412ae8e-462e-48e3-b7fe-f9aea9b6e150"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""481355d4-f642-4868-9b48-a65a73d05337"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AutoAttack"",
                    ""type"": ""Button"",
                    ""id"": ""e3325ccc-208d-44e0-a893-eaf5ce7a6669"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FirstAbility"",
                    ""type"": ""Button"",
                    ""id"": ""5f8475e1-0809-4c42-b5e5-86387147f725"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondAbility"",
                    ""type"": ""Button"",
                    ""id"": ""d9134870-5886-4408-8eb5-6e732cdde9ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThirdAbility"",
                    ""type"": ""Button"",
                    ""id"": ""cd84093c-c77a-43ea-9df9-42e9696852ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASDKeys"",
                    ""id"": ""08214dbc-7244-4ff5-99c6-7177542f0248"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1f3a04ad-e573-4e4c-b2a2-7b53d7e3756a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""50386c30-e7f1-476d-99d3-e226beffd92e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bf5614eb-a137-4cd9-8090-9c8201d97a55"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d1e72d79-9331-471f-9862-4cae8fb60f98"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""902367a4-ffe6-47db-a7e2-6356907b8753"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be8054b8-1df9-401b-9c52-124f8c0a8c05"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a851679-04c2-4f01-aebd-088dd27ea7f9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThirdAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ac5edb1-79a7-4df7-998f-beb4ca2faaa7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AutoAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerMouse
        m_PlayerMouse = asset.FindActionMap("PlayerMouse", throwIfNotFound: true);
        m_PlayerMouse_Move = m_PlayerMouse.FindAction("Move", throwIfNotFound: true);
        m_PlayerMouse_AutoAttack = m_PlayerMouse.FindAction("AutoAttack", throwIfNotFound: true);
        m_PlayerMouse_FirstAbility = m_PlayerMouse.FindAction("FirstAbility", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_LockCamera = m_Camera.FindAction("LockCamera", throwIfNotFound: true);
        // PlayerController
        m_PlayerController = asset.FindActionMap("PlayerController", throwIfNotFound: true);
        m_PlayerController_Move = m_PlayerController.FindAction("Move", throwIfNotFound: true);
        m_PlayerController_AutoAttack = m_PlayerController.FindAction("AutoAttack", throwIfNotFound: true);
        m_PlayerController_FirstAbility = m_PlayerController.FindAction("FirstAbility", throwIfNotFound: true);
        m_PlayerController_SecondAbility = m_PlayerController.FindAction("SecondAbility", throwIfNotFound: true);
        m_PlayerController_ThirdAbility = m_PlayerController.FindAction("ThirdAbility", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerMouse
    private readonly InputActionMap m_PlayerMouse;
    private IPlayerMouseActions m_PlayerMouseActionsCallbackInterface;
    private readonly InputAction m_PlayerMouse_Move;
    private readonly InputAction m_PlayerMouse_AutoAttack;
    private readonly InputAction m_PlayerMouse_FirstAbility;
    public struct PlayerMouseActions
    {
        private @MyInputManager m_Wrapper;
        public PlayerMouseActions(@MyInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMouse_Move;
        public InputAction @AutoAttack => m_Wrapper.m_PlayerMouse_AutoAttack;
        public InputAction @FirstAbility => m_Wrapper.m_PlayerMouse_FirstAbility;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMouseActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMouseActions instance)
        {
            if (m_Wrapper.m_PlayerMouseActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnMove;
                @AutoAttack.started -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnAutoAttack;
                @AutoAttack.performed -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnAutoAttack;
                @AutoAttack.canceled -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnAutoAttack;
                @FirstAbility.started -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnFirstAbility;
                @FirstAbility.performed -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnFirstAbility;
                @FirstAbility.canceled -= m_Wrapper.m_PlayerMouseActionsCallbackInterface.OnFirstAbility;
            }
            m_Wrapper.m_PlayerMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @AutoAttack.started += instance.OnAutoAttack;
                @AutoAttack.performed += instance.OnAutoAttack;
                @AutoAttack.canceled += instance.OnAutoAttack;
                @FirstAbility.started += instance.OnFirstAbility;
                @FirstAbility.performed += instance.OnFirstAbility;
                @FirstAbility.canceled += instance.OnFirstAbility;
            }
        }
    }
    public PlayerMouseActions @PlayerMouse => new PlayerMouseActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_LockCamera;
    public struct CameraActions
    {
        private @MyInputManager m_Wrapper;
        public CameraActions(@MyInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @LockCamera => m_Wrapper.m_Camera_LockCamera;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @LockCamera.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLockCamera;
                @LockCamera.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLockCamera;
                @LockCamera.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLockCamera;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LockCamera.started += instance.OnLockCamera;
                @LockCamera.performed += instance.OnLockCamera;
                @LockCamera.canceled += instance.OnLockCamera;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // PlayerController
    private readonly InputActionMap m_PlayerController;
    private IPlayerControllerActions m_PlayerControllerActionsCallbackInterface;
    private readonly InputAction m_PlayerController_Move;
    private readonly InputAction m_PlayerController_AutoAttack;
    private readonly InputAction m_PlayerController_FirstAbility;
    private readonly InputAction m_PlayerController_SecondAbility;
    private readonly InputAction m_PlayerController_ThirdAbility;
    public struct PlayerControllerActions
    {
        private @MyInputManager m_Wrapper;
        public PlayerControllerActions(@MyInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerController_Move;
        public InputAction @AutoAttack => m_Wrapper.m_PlayerController_AutoAttack;
        public InputAction @FirstAbility => m_Wrapper.m_PlayerController_FirstAbility;
        public InputAction @SecondAbility => m_Wrapper.m_PlayerController_SecondAbility;
        public InputAction @ThirdAbility => m_Wrapper.m_PlayerController_ThirdAbility;
        public InputActionMap Get() { return m_Wrapper.m_PlayerController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControllerActions instance)
        {
            if (m_Wrapper.m_PlayerControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnMove;
                @AutoAttack.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnAutoAttack;
                @AutoAttack.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnAutoAttack;
                @AutoAttack.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnAutoAttack;
                @FirstAbility.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnFirstAbility;
                @FirstAbility.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnFirstAbility;
                @FirstAbility.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnFirstAbility;
                @SecondAbility.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSecondAbility;
                @SecondAbility.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSecondAbility;
                @SecondAbility.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSecondAbility;
                @ThirdAbility.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnThirdAbility;
                @ThirdAbility.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnThirdAbility;
                @ThirdAbility.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnThirdAbility;
            }
            m_Wrapper.m_PlayerControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @AutoAttack.started += instance.OnAutoAttack;
                @AutoAttack.performed += instance.OnAutoAttack;
                @AutoAttack.canceled += instance.OnAutoAttack;
                @FirstAbility.started += instance.OnFirstAbility;
                @FirstAbility.performed += instance.OnFirstAbility;
                @FirstAbility.canceled += instance.OnFirstAbility;
                @SecondAbility.started += instance.OnSecondAbility;
                @SecondAbility.performed += instance.OnSecondAbility;
                @SecondAbility.canceled += instance.OnSecondAbility;
                @ThirdAbility.started += instance.OnThirdAbility;
                @ThirdAbility.performed += instance.OnThirdAbility;
                @ThirdAbility.canceled += instance.OnThirdAbility;
            }
        }
    }
    public PlayerControllerActions @PlayerController => new PlayerControllerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerMouseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAutoAttack(InputAction.CallbackContext context);
        void OnFirstAbility(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnLockCamera(InputAction.CallbackContext context);
    }
    public interface IPlayerControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAutoAttack(InputAction.CallbackContext context);
        void OnFirstAbility(InputAction.CallbackContext context);
        void OnSecondAbility(InputAction.CallbackContext context);
        void OnThirdAbility(InputAction.CallbackContext context);
    }
}
