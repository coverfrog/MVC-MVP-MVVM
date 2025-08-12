using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private MoveInputActor mMoveActor;
    
    public void Spawn()
    {
        if (!TryGetComponent(out NetworkObject networkObject))
        {
            return;
        }

        networkObject.InstantiateAndSpawn(NetworkManager.Singleton);
    }

    public override void OnNetworkSpawn()
    {
        SetName();
        SetController();
    }

    private void SetName()
    {
        gameObject.name = $"Network Player [ {(IsOwner ? "Me" : "Other")} ]";
    }

    private void SetController()
    {
        if (!IsOwner)
        {
            return;
        }

        InputContexts.Register(OwnerClientId, OnInput);
    }

    private void OnInput(ulong ownerClientId, InputContext context)
    {
        mMoveActor?.OnInput(context);
    }
}
