using System;
using Reflex.Core;
using Storage.Gameplay;

namespace Core.DI.SceneContainerBuilders
{
    public class GameplaySceneParameters : SceneParameters
    {
        public override void Configure(ContainerBuilder builder)
        {
            builder.SetName($"GameplayScene");

            builder.AddSingleton(
                typeof(GameplayStorage),
                new[]
                {
                    typeof(IGameplayStorage),
                    typeof(IDisposable),
                }
            );
        }
    }
}