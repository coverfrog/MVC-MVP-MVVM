using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneMainMenuInit))]
[RequireComponent(typeof(SceneMainMenuWaitNetwork))]
[RequireComponent(typeof(SceneMainMenuIdle))]
public class SceneMainMenu : SceneHandler
{
    [SerializeField] private SceneMainMenuContext mContext;
    [Space]
    [SerializeField] private SceneMainMenuInit mInit;
    [SerializeField] private SceneMainMenuWaitNetwork mWaitNetwork;
    [SerializeField] private SceneMainMenuIdle mIdle;

    private SceneMainMenuFsm _mFsm;
    
    public override void OnSceneLoadEventCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        
    }
    
    private void Start()
    {
        ChangeState(SceneMainMenuState.Init);
    }

    private void Update()
    {
        _mFsm?.OnUpdate(this, mContext);
    }

    public void ChangeState(SceneMainMenuState state)
    {
        mContext.state = state;

        _mFsm?.OnExit(this, mContext);
        _mFsm = state switch
        {
            SceneMainMenuState.Init => mInit,
            SceneMainMenuState.WaitNetwork => mWaitNetwork,
            SceneMainMenuState.Idle => mIdle,
            _ => null
        };

        _mFsm?.OnEnter(this, mContext);
    }

    public void StartHost()
    {
        mContext.hostButton.interactable = false;
        mContext.clientButton.interactable = false;
        
        NetworkManager.Singleton.StartHost();
        
        OnClientConnected(NetworkManager.Singleton.LocalClientId);
    }

    public void StartClient()
    {
        mContext.hostButton.interactable = false;
        mContext.clientButton.interactable = false;
        
        NetworkManager.Singleton.StartClient();
    }

    public void OnClientConnected(ulong id)
    {
        mContext.hostButton.gameObject.SetActive(false);
        mContext.clientButton.gameObject.SetActive(false);

        mContext.startButton.interactable = NetworkManager.Singleton.IsHost;
        mContext.startButton.gameObject.SetActive(true);
    }
    
    public void StartGame()
    {
        if (!NetworkManager.Singleton.IsHost)
        {
            return;
        }
        
        NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }


    
}