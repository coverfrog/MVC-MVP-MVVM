using UnityEngine;

public abstract class SceneGameFsm : MonoBehaviour, IFsm<SceneGame, SceneGameContext>
{
    public abstract void OnEnter(SceneGame handler, SceneGameContext context);

    public abstract void OnUpdate(SceneGame handler, SceneGameContext context);

    public abstract void OnExit(SceneGame handler, SceneGameContext context);
}