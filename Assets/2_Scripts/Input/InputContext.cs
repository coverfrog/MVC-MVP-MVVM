using System;
using System.Collections.Generic;
using UnityEngine;

public static class InputContexts
{
    public delegate void OnInputDelegate(ulong ownerClientId, InputContext context);
    
    private static readonly Dictionary<ulong, OnInputDelegate> Contexts = new Dictionary<ulong, OnInputDelegate>();
    
    private static readonly InputContext InputContext = new InputContext();
    
    public static void Register(ulong ownerClientId, OnInputDelegate callback)
    {
        if (Contexts.TryAdd(ownerClientId, callback))
        {
            return;
        }

        Contexts[ownerClientId] = callback;
    }
    
    public static void UnRegister(ulong ownerClientId)
    {
        Contexts.Remove(ownerClientId);
    }

    public static void OnInput(InputObserver observer)
    {
        foreach (KeyValuePair<ulong, OnInputDelegate> pair in Contexts)
        {
            pair.Value(pair.Key, InputContext);
        }
    }
    
    public static void SetMovement(InputObserver observer, Vector3 movement) => 
        InputContext.movement = movement;
}

[Serializable]
public class InputContext
{
    public Vector3 movement = Vector3.zero;
}