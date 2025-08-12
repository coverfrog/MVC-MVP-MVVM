using Unity.Netcode;

public class SceneMainMenuInit : SceneMainMenuFsm
{
    public override void OnEnter(SceneMainMenu handler, SceneMainMenuContext context)
    {
        context.hostButton.onClick.AddListener(handler.StartHost);
        context.hostButton.gameObject.SetActive(true);
        
        context.clientButton.onClick.AddListener(handler.StartClient);
        context.clientButton.gameObject.SetActive(true);
        
        context.startButton.onClick.AddListener(handler.StartGame);
        context.startButton.gameObject.SetActive(false);
        
        handler.ChangeState(SceneMainMenuState.Idle);
    }

    public override void OnUpdate(SceneMainMenu handler, SceneMainMenuContext context)
    {

    }

    public override void OnExit(SceneMainMenu handler, SceneMainMenuContext context)
    {
       
    }
}