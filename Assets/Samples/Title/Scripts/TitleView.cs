using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleView : MonoBehaviour
{
    [SerializeField] private TitleOption option;
    
    private TitleViewModel _vm;

    private void Start()
    {
        TitleModel model = new TitleModel();

        _vm = new TitleViewModel(model);

        Observable.Timer(TimeSpan.FromSeconds(option.duration))
            .Subscribe(_ => GoNextScene())
            .AddTo(this);
    }

    private void GoNextScene()
    {
        SceneManager.LoadScene(option.nextSceneName);
    }
}
