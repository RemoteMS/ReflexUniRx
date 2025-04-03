using DataFlow.Interfaces;
using Reflex.Attributes;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Global.Controls
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button toGameplayButton;

        private readonly CompositeDisposable _disposables = new();

        [Inject]
        public void Inject(ISceneLoader sceneLoader)
        {
            toGameplayButton.OnClickAsObservable()
                .Subscribe(
                    _ => { sceneLoader.LoadGamePlay(); })
                .AddTo(_disposables);
        }

        private void OnDestroy()
        {
            _disposables?.Dispose();
        }
    }
}