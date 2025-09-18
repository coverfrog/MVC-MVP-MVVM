using UniRx;
using UnityEngine;

public class ScoreModel
{
    public ReactiveProperty<int> Score { get; } = new ReactiveProperty<int>(0);
    
    public void AddScore(int value) 
    {
        Score.Value += value;
    }
}
