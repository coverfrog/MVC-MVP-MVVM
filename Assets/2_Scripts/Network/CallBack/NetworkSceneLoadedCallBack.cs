using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkSceneLoadedCallBack : MonoBehaviour
{
    private IEnumerator Start()
    {
        while (ReferenceEquals(NetworkManager.Singleton, null))
        {
            yield return null;
        }
        
        while (ReferenceEquals(NetworkManager.Singleton.SceneManager, null))
        {
            yield return null;
        }

        DontDestroyOnLoad(gameObject);
        
        NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += OnSceneLoadEventCompleted;
    }

    private void OnDestroy()
    {
        if (ReferenceEquals(NetworkManager.Singleton, null))
        {
            return;
        }
        
        if (ReferenceEquals(NetworkManager.Singleton.SceneManager, null))
        {
            return;
        }
        
        NetworkManager.Singleton.SceneManager.OnLoadEventCompleted -= OnSceneLoadEventCompleted;
    }

    private static void OnSceneLoadEventCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        FindAnyObjectByType<SceneHandler>().OnSceneLoadEventCompleted(sceneName, loadSceneMode, clientsCompleted, clientsTimedOut);
    }
}