using UniRx;
using UnityEngine;

public class ScoreViewModel
{
    private readonly ScoreModel _model;
    
    public IReadOnlyReactiveProperty<int> Score => _model.Score;

    public ScoreViewModel(ScoreModel model) 
    {
        _model = model;
    }

    public void AddScore(int value) 
    {
        _model.AddScore(value);
    }
}
