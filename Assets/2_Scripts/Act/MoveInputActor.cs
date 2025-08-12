using UnityEngine;

public abstract class MoveInputActor : MoveActor
{
    [SerializeField] protected MoveContext mContext;
    
    public abstract void OnInput(InputContext inputContext);

}