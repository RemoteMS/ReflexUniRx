using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.Global.ResourceManagers.Interfaces
{
    public interface IDataManager
    {
        UniTask InitializeAsync();
        UniTask<T> LoadAssetAsync<T>(string path) where T : Object;
        UniTask<IList<T>> LoadAssetsByPathAsync<T>(string path) where T : Object;

        UniTask<GameObject> InstantiatePrefabAsync(string path, Vector3 position = default,
            Quaternion rotation = default, Transform parent = null);

        void UnloadAsset(string path);
        void UnloadPrefab(string path);
        void UnloadAllAssets();
        void UnloadAllPrefabs();
    }
}