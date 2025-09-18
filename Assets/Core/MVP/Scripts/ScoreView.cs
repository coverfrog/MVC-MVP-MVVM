using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour, IScoreView 
{
    public TMP_Text mScoreText;

    public void ShowScore(int score)
    {
        mScoreText.text =  $"Score: {score}";
    }
}
