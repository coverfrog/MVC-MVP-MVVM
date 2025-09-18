using UnityEngine;

public class ScorePresenter 
{
    private readonly ScoreModel _model;
    private readonly IScoreView _view;

    public ScorePresenter(ScoreModel model, IScoreView view) 
    {
        _model = model;
        _view = view;
        
        view.ShowScore(model.Score);
    }

    public void OnAddScore() 
    {
        _model.AddScore(10);
        _view.ShowScore(_model.Score);
    }
}
