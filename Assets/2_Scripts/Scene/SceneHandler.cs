using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneHandler : MonoBehaviour, INetworkSceneLoaded
{
    public abstract void OnSceneLoadEventCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut);
}