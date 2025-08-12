using UnityEngine;

public abstract class SceneMainMenuFsm : MonoBehaviour, IFsm<SceneMainMenu, SceneMainMenuContext>
{
    public abstract void OnEnter(SceneMainMenu handler, SceneMainMenuContext context);

    public abstract void OnUpdate(SceneMainMenu handler, SceneMainMenuContext context);

    public abstract void OnExit(SceneMainMenu handler, SceneMainMenuContext context);
}