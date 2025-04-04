using System;
using DataFlow;
using DataFlow.Interfaces;
using Global.Testing;
using Reflex.Core;
using Storage.Global;
using UnityEngine;

namespace Core.DI
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(GlobalStorage), typeof(GlobalStorage), typeof(IDisposable));

            builder.AddSingleton(typeof(SceneLoader), new[] { typeof(ISceneLoader), typeof(IDisposable) });
            builder.AddSingleton(typeof(TestService), new[] { typeof(ITestService), typeof(IDisposable) });

            builder.OnContainerBuilt += OnBuild;
        }

        private void OnBuild(Container obj)
        {
            obj.Resolve<ISceneLoader>();
            obj.Resolve<ITestService>();

            App.AutostartGame(obj);
        }
    }
}