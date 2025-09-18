using UnityEngine;

public class ScoreBootstrap : MonoBehaviour
{
    [SerializeField] private ScoreView view;
    
    private ScorePresenter _presenter;

    private void Start() 
    {
        _presenter = new ScorePresenter(new ScoreModel(), view);
    }

    public void OnClickAddScore() 
    {
        _presenter.OnAddScore();
    }
}
