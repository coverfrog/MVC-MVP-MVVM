using System.Collections.Generic;
using UnityEngine.SceneManagement;

public interface INetworkSceneLoaded
{
    void OnSceneLoadEventCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut);
}