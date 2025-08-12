using System;

[Serializable]
public class SceneGameContext
{
    [Serializable]
    public class Origins
    {
        public NetworkPlayer networkPlayer;
    }
    
    public SceneGameState state = SceneGameState.None;
    public NetworkRole networkRole = NetworkRole.None;
    public Origins origins =  new Origins();
}