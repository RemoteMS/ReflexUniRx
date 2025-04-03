using DataFlow.Interfaces;
using Reflex.Attributes;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Global.Controls
{
    public class Gameplay : MonoBehaviour
    {
        [SerializeField] private Button toMenuButton;

        private readonly CompositeDisposable _disposables = new();

        [Inject]
        public void Inject(ISceneLoader sceneLoader)
        {
            toMenuButton.OnClickAsObservable()
                .Subscribe(
                    _ => { sceneLoader.LoadMainMenu(); })
                .AddTo(_disposables);
        }

        private void OnDestroy()
        {
            _disposables?.Dispose();
        }
    }
}