using Cysharp.Threading.Tasks;
using DataFlow.Enums;
using UniRx;

namespace DataFlow.Interfaces
{
    public interface ISceneLoader
    {
        UniTask LoadGamePlay();
        UniTask LoadMainMenu();
        IReadOnlyReactiveProperty<SceneLoadState> sceneStateStatus { get; }
    }
}