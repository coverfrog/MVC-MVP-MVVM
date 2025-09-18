using TMPro;
using UniRx;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    public TMP_Text mScoreText;

    private ScoreViewModel _vm;

    private void Start() 
    {
        ScoreModel m = new ScoreModel();
        
        _vm = new ScoreViewModel(m);

        _vm.Score.Subscribe(score => mScoreText.text = $"Score: {score}").AddTo(this);
    }

    public void OnClickAddScore() {
        _vm.AddScore(10);
    }
}