using DataFlow.Interfaces;
using Global.Testing;
using Reflex.Core;
using UnityEngine.SceneManagement;

public class App
{
    private static App _instance;

    private readonly Container _rootContainer;
    private Container _cachedSceneContainer;
    private readonly ISceneLoader _sceneLoader;
    private readonly ITestService _testService;

    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame(Container projectRootContainer)
    {
        _instance = new App(projectRootContainer);
        _instance.RunGame();
    }

    private App(Container rootContainer)
    {
        _rootContainer = rootContainer;
        _sceneLoader = _rootContainer.Resolve<ISceneLoader>();
        _testService = _rootContainer.Resolve<ITestService>();
    }

    private async void RunGame()
    {
#if UNITY_EDITOR
        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == Scenes.Gameplay)
        {
            await _sceneLoader.LoadGamePlay();

            return;
        }

        if (sceneName == Scenes.MainMenu)
        {
            await _sceneLoader.LoadMainMenu();
            return;
        }

        if (sceneName == Scenes.TestScene)
        {
            return;
        }

        if (sceneName is Scenes.Boot)
        {
            await _sceneLoader.LoadMainMenu();
            return;
        }
#endif
        await _sceneLoader.LoadMainMenu();
    }
}