using UnityEngine;
using UnityEngine.Pool;

public abstract class AbstractMonoBehaviourPool<T> : MonoBehaviour where T : MonoBehaviour
{
	[SerializeField]
	protected T _prefab;

	private IObjectPool<T> _pool;

	public void InitializePool()
	{
		_pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject);
	}

	protected virtual T CreatePooledItem()
	{
		return Instantiate(_prefab);
	}

	protected virtual void OnReturnedToPool(T @object)
	{
		@object.gameObject.SetActive(false);
		@object.transform.SetParent(this.transform);
	}

	protected virtual void OnTakeFromPool(T @object)
	{
		@object.gameObject.SetActive(true);
		@object.transform.SetParent(null);
	}

	protected virtual void OnDestroyPoolObject(T @object)
	{
		@object.gameObject.SetActive(false);
		@object.transform.SetParent(this.transform);
	}

	public T Get()
	{
		return _pool.Get();
	}

	public void Release(T @object)
	{
		_pool.Release(@object);
	}
}
