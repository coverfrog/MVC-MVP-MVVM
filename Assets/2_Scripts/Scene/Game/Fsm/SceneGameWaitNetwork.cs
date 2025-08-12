using Unity.Netcode;

public class SceneGameWaitNetwork : SceneGameFsm
{
    public override void OnEnter(SceneGame handler, SceneGameContext context)
    {
            
    }

    public override void OnUpdate(SceneGame handler, SceneGameContext context)
    {
        if (!NetworkManager.Singleton)
        {
            return;
        }
        
        context.networkRole = NetworkManager.Singleton.IsHost ? NetworkRole.Host : NetworkRole.Client;
        handler.ChangeState(SceneGameState.StartProduction);
    }

    public override void OnExit(SceneGame handler, SceneGameContext context)
    {
            
    }
}