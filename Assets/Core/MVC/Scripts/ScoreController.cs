using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public ScoreView view;

    private ScoreModel _mModel;

    private void Start()
    {
        _mModel = new ScoreModel();
        
        view.UpdateScore(_mModel.Score);
    }

    public void OnClickAddScore()
    {
        _mModel.AddScore(10);
        
        view.UpdateScore(_mModel.Score);
    }
}