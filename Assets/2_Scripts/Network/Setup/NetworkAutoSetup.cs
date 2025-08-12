using Unity.Netcode;
using UnityEngine;

public static class NetworkAutoSetup
{
    private const string NetworkManagerPath = "Network Manager";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Setup()
    {
        // --> network manager
        
        ResourceRequest request = Resources.LoadAsync<GameObject>(NetworkManagerPath);
        
        request.completed += _ =>
        {
            if (request.asset is GameObject resource)
            {
                GameObject obj = Object.Instantiate(resource);
                obj.name = "Network Manager";
                
                return;
            }
            
            Debug.Assert(false, "Network Manager Setup Failed");
        };
        
        // --> network scene loaded call back
        
        _ = new GameObject("Network Scene Loaded CallBack").AddComponent<NetworkSceneLoadedCallBack>();
    }
}
