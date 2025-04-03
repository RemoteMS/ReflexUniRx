using System;
using DataFlow.Interfaces;
using UniRx;
using UnityEngine;

namespace Global.Testing
{
    public interface ITestService : IDisposable
    {
    }

    public class TestService : ITestService, IDisposable
    {
        private readonly CompositeDisposable _disposables = new();

        public TestService(ISceneLoader sceneLoader)
        {
            Debug.LogWarning($"1 _ {GetType().Name} initialized");

            sceneLoader.sceneStateSubject
                .Subscribe(x => { Debug.LogWarning($"1 _ update in sceneStateSubject {x}"); })
                .AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
            Debug.LogWarning($"1 _ {GetType().Name} disposed");
        }
    }
}