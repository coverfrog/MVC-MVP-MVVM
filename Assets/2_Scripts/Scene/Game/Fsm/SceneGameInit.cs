using Unity.Netcode;
using UnityEngine;

public class SceneGameInit : SceneGameFsm
{
    public override void OnEnter(SceneGame handler, SceneGameContext context)
    {
        SpawnPlayer(context);
        
        handler.ChangeState(SceneGameState.WaitNetwork);
    }

    public override void OnUpdate(SceneGame handler, SceneGameContext context)
    {
       
    }

    public override void OnExit(SceneGame handler, SceneGameContext context)
    {
       
    }

    private static void SpawnPlayer(SceneGameContext context)
    {
        context.origins.networkPlayer.Spawn();
    }
}