// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""d66a0e9f-689a-41c6-ae10-bb50118d9fab"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a0357865-12ea-4134-b5e3-9fa6f79f4309"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bullet1"",
                    ""type"": ""Button"",
                    ""id"": ""88030309-bd45-4d0c-babf-53cc1d1d5d33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bullet2"",
                    ""type"": ""Button"",
                    ""id"": ""4a7d52fc-153e-4984-81e7-0112cc743b1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bullet3"",
                    ""type"": ""Button"",
                    ""id"": ""4f2547e4-d017-462d-9a5f-49eed3be8ae2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bullet4"",
                    ""type"": ""Button"",
                    ""id"": ""81948cdf-ba1d-4936-9f9c-f3f923e0e9ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item"",
                    ""type"": ""Button"",
                    ""id"": ""26e7011a-1e4e-4941-95b2-eb092e491559"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""c1f9beb1-087e-4b15-8072-2f4a3e7674ed"",
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
                    ""id"": ""c4f614b3-7e16-4d2b-b175-3af8a8979299"",
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
                    ""id"": ""8e0caeb5-9484-4555-9571-65009b584ca7"",
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
                    ""id"": ""ceb04392-4440-4e7b-a133-afcdea317bed"",
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
                    ""id"": ""cce46b5d-d104-4660-826a-582210cfe6f1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""615f3bc9-16a0-495d-a3f1-15fc176e863c"",
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
                    ""id"": ""70c31a5d-c13a-4588-9e7a-c749a4c9c408"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""47845f6f-5654-4957-8ed2-11ed443b0ae5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""85915859-e158-4cd2-8a61-d1f970baa040"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c1c1e15c-dedb-4097-84c6-3b06a9efe090"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""00e4ecbf-69c6-4df3-9c94-08d420c3cb3f"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bullet1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""420df2cb-33c3-4713-8507-7b25bc3958b2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bullet1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6abd7576-f3f8-4899-a16e-071b06ac6853"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bullet2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0a2af65-869c-43db-b7fc-775ce43d8faa"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bullet2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc579f21-7e4f-4670-a8db-7219a8a41cb3"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bullet3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5638c219-dbf0-4cb8-9cb5-7af36546c5ff"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bullet3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1160f76-3f05-47c7-99df-4da1cfceef39"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bullet4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e137a74c-66c9-40e7-a38d-6dacc4b3ac9c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bullet4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3289567-0ef4-45ac-8988-bb55c7f0875d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b91453c-ba38-48c2-ba4c-d86484ca1516"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Bullet1 = m_GamePlay.FindAction("Bullet1", throwIfNotFound: true);
        m_GamePlay_Bullet2 = m_GamePlay.FindAction("Bullet2", throwIfNotFound: true);
        m_GamePlay_Bullet3 = m_GamePlay.FindAction("Bullet3", throwIfNotFound: true);
        m_GamePlay_Bullet4 = m_GamePlay.FindAction("Bullet4", throwIfNotFound: true);
        m_GamePlay_Item = m_GamePlay.FindAction("Item", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Bullet1;
    private readonly InputAction m_GamePlay_Bullet2;
    private readonly InputAction m_GamePlay_Bullet3;
    private readonly InputAction m_GamePlay_Bullet4;
    private readonly InputAction m_GamePlay_Item;
    public struct GamePlayActions
    {
        private @PlayerInput m_Wrapper;
        public GamePlayActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Bullet1 => m_Wrapper.m_GamePlay_Bullet1;
        public InputAction @Bullet2 => m_Wrapper.m_GamePlay_Bullet2;
        public InputAction @Bullet3 => m_Wrapper.m_GamePlay_Bullet3;
        public InputAction @Bullet4 => m_Wrapper.m_GamePlay_Bullet4;
        public InputAction @Item => m_Wrapper.m_GamePlay_Item;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Bullet1.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet1;
                @Bullet1.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet1;
                @Bullet1.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet1;
                @Bullet2.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet2;
                @Bullet2.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet2;
                @Bullet2.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet2;
                @Bullet3.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet3;
                @Bullet3.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet3;
                @Bullet3.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet3;
                @Bullet4.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet4;
                @Bullet4.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet4;
                @Bullet4.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBullet4;
                @Item.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnItem;
                @Item.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnItem;
                @Item.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnItem;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Bullet1.started += instance.OnBullet1;
                @Bullet1.performed += instance.OnBullet1;
                @Bullet1.canceled += instance.OnBullet1;
                @Bullet2.started += instance.OnBullet2;
                @Bullet2.performed += instance.OnBullet2;
                @Bullet2.canceled += instance.OnBullet2;
                @Bullet3.started += instance.OnBullet3;
                @Bullet3.performed += instance.OnBullet3;
                @Bullet3.canceled += instance.OnBullet3;
                @Bullet4.started += instance.OnBullet4;
                @Bullet4.performed += instance.OnBullet4;
                @Bullet4.canceled += instance.OnBullet4;
                @Item.started += instance.OnItem;
                @Item.performed += instance.OnItem;
                @Item.canceled += instance.OnItem;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnBullet1(InputAction.CallbackContext context);
        void OnBullet2(InputAction.CallbackContext context);
        void OnBullet3(InputAction.CallbackContext context);
        void OnBullet4(InputAction.CallbackContext context);
        void OnItem(InputAction.CallbackContext context);
    }
}
