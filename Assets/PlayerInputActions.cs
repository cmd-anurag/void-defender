//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Spaceship"",
            ""id"": ""d1dddf44-12c0-4461-b281-8b020432223e"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""5984a939-d186-42ab-a633-eae2d5c7d69b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""c6383cdc-275b-4acc-91c6-fb0a1f70bea9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4723ab1a-3463-4180-8ac6-9a04ba102caf"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5693384f-6d2b-4f41-9c60-58d793e5e70f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Spaceship
        m_Spaceship = asset.FindActionMap("Spaceship", throwIfNotFound: true);
        m_Spaceship_Look = m_Spaceship.FindAction("Look", throwIfNotFound: true);
        m_Spaceship_Shoot = m_Spaceship.FindAction("Shoot", throwIfNotFound: true);
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

    // Spaceship
    private readonly InputActionMap m_Spaceship;
    private List<ISpaceshipActions> m_SpaceshipActionsCallbackInterfaces = new List<ISpaceshipActions>();
    private readonly InputAction m_Spaceship_Look;
    private readonly InputAction m_Spaceship_Shoot;
    public struct SpaceshipActions
    {
        private @PlayerInputActions m_Wrapper;
        public SpaceshipActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_Spaceship_Look;
        public InputAction @Shoot => m_Wrapper.m_Spaceship_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Spaceship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceshipActions set) { return set.Get(); }
        public void AddCallbacks(ISpaceshipActions instance)
        {
            if (instance == null || m_Wrapper.m_SpaceshipActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SpaceshipActionsCallbackInterfaces.Add(instance);
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(ISpaceshipActions instance)
        {
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(ISpaceshipActions instance)
        {
            if (m_Wrapper.m_SpaceshipActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISpaceshipActions instance)
        {
            foreach (var item in m_Wrapper.m_SpaceshipActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SpaceshipActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SpaceshipActions @Spaceship => new SpaceshipActions(this);
    public interface ISpaceshipActions
    {
        void OnLook(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
