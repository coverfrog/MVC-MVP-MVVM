using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputObserver : MonoBehaviour
{
    private InputContext _mInputContext;
    
    private PlayerInput _mPlayerInput;
    
    private void Start()
    {
        Init();
        Move();
    }

    private void Init()
    {
        _mInputContext = new InputContext();
        _mPlayerInput = GetComponent<PlayerInput>();
    }

    private InputAction GetAsset(string key) => _mPlayerInput.actions[key];
    
    private void Move()
    {
        const string key = "Move";
        
        InputAction asset = GetAsset(key);
        
        asset.performed += ctx =>
        {
            OnInput(ctx.ReadValue<Vector2>());
        };

        asset.canceled += ctx =>
        {
            OnInput(Vector2.zero);
        };

        return;

        void OnInput(Vector2 source)
        {
            InputContexts.SetMovement(this, new Vector3(source.x, 0, source.y));
            InputContexts.OnInput(this);
        }
    }
}