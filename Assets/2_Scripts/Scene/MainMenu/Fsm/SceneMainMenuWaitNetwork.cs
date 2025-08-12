using System;
using Unity.Netcode;

public class SceneMainMenuWaitNetwork : SceneMainMenuFsm
{
    private SceneMainMenu _mHandler;
    
    public override void OnEnter(SceneMainMenu handler, SceneMainMenuContext context)
    {
        _mHandler = handler;
    }

    public override void OnUpdate(SceneMainMenu handler, SceneMainMenuContext context)
    {
        if (!NetworkManager.Singleton)
        {
            return;
        }
        
        NetworkManager.Singleton.OnClientConnectedCallback += handler.OnClientConnected;
        
        handler.ChangeState(SceneMainMenuState.Idle);
    }

    public override void OnExit(SceneMainMenu handler, SceneMainMenuContext context)
    {
            
    }

    private void OnDestroy()
    {
        if (!_mHandler)
        {
            return;
        }

        NetworkManager.Singleton.OnClientConnectedCallback -= _mHandler.OnClientConnected;
    }
    
    
}