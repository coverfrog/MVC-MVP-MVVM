using UnityEngine;

public class MoveInputSimpleActor : MoveInputActor
{
    public override void OnInput(InputContext inputContext)
    {
        Vector3 movement = inputContext.movement;
        
        mContext.rigidBody.linearVelocity = movement * mContext.speed;
    }
}