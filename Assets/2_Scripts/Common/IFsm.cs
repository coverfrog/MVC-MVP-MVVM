using UnityEngine;

public interface IFsm<in THandler, in TContext> where THandler : Behaviour
{
    public void OnEnter(THandler handler, TContext context);

    public void OnUpdate(THandler handler, TContext context);
    
    public void OnExit(THandler handler, TContext context);
}