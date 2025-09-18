using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    public TMP_Text mScoreText;

    public void UpdateScore(int score)
    {
        mScoreText.text =  $"Score: {score}";
    }
}
