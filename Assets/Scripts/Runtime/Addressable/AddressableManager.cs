using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : MonoBehaviour
{
	private readonly List<AsyncOperationHandle> _operationHandlers = new();

	public void Load(string key, Action<GameObject> onAssetLoadedCallback)
	{
		StartCoroutine(LoadAssetAsync(key, onAssetLoadedCallback));
	}

	private IEnumerator LoadAssetAsync(string key, Action<GameObject> onAssetLoadedCallback)
	{
		var opHandle = Addressables.LoadAssetAsync<GameObject>(key);

		TryCacheHandlers(opHandle);

		yield return opHandle;

		if (opHandle.Status == AsyncOperationStatus.Succeeded)
		{
			var obj = opHandle.Result;
			var loadedAsset = Instantiate(obj);
			onAssetLoadedCallback?.Invoke(loadedAsset);
		}
	}

	private void TryCacheHandlers(AsyncOperationHandle opHandle)
	{
		if (!_operationHandlers.Contains(opHandle))
		{
			_operationHandlers.Add(opHandle);
		}
	}

	private void OnDestroy()
	{
		foreach (var opHandler in _operationHandlers)
		{
			Release(opHandler);
		}

		_operationHandlers.Clear();
	}

	private void Release(AsyncOperationHandle opHandle)
	{
		if (_operationHandlers.Contains(opHandle))
		{
			Addressables.Release(opHandle);
		}
	}
}
