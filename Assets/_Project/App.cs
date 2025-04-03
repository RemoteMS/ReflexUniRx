using DataFlow.Interfaces;
using Global.Testing;
using Reflex.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App
{
    private static App _instance;

    private readonly Container _rootContainer;
    private Container _cachedSceneContainer;
    private readonly ISceneLoader _sceneLoader;
    private readonly ITestService _testService;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame()
    {
        _instance = new App();
        _instance.RunGame();
    }

    private App()
    {
        _rootContainer = CreateProjectContainer.Create();
        _sceneLoader = _rootContainer.Resolve<ISceneLoader>();
        _testService = _rootContainer.Resolve<ITestService>();

        var asyncSceneLoader = new GameObject("[AsyncSceneLoader]");
        Object.DontDestroyOnLoad(asyncSceneLoader);

        var scopes = new GameObject("[SCOPE]");
        Object.DontDestroyOnLoad(scopes);

        // you can remove it
        var k = new GameObject("[TestServiceKeeper]");
        var testServiceKeeper = k.AddComponent<TestServiceKeeper>();
        testServiceKeeper.keeper = _testService;
        Object.DontDestroyOnLoad(k);
        // you can remove it
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