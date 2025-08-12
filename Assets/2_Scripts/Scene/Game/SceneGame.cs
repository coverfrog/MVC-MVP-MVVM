using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneGameInit))]
[RequireComponent(typeof(SceneGameWaitNetwork))]
[RequireComponent(typeof(SceneGameStartProduction))]
public class SceneGame : SceneHandler
{
    [Header("[ Context ]")] 
    [SerializeField] private SceneGameContext mContext;

    [Header("[ Fsm ]")] 
    [SerializeField] private SceneGameInit mInit;
    [SerializeField] private SceneGameWaitNetwork mWaitNetwork;
    [SerializeField] private SceneGameStartProduction mStartProduction;

    private SceneGameFsm _mFsm;

    public override void OnSceneLoadEventCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        ChangeState(SceneGameState.Init);
    }
    
    private void Update()
    {
        _mFsm?.OnUpdate(this, mContext);
    }

    public void ChangeState(SceneGameState state)
    {
        mContext.state = state;

        _mFsm?.OnExit( this, mContext);
        _mFsm = state switch
        {
            SceneGameState.Init => mInit,
            SceneGameState.WaitNetwork => mWaitNetwork,
            SceneGameState.StartProduction => mStartProduction,
            _ => null
        };

        _mFsm?.OnEnter( this, mContext);
    }

    
}