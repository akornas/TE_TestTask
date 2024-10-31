using UnityEngine;
using UnityEngine.Pool;

public class BulletBehaviourPool : MonoBehaviour
{
	[SerializeField]
	private BulletBehaviour _bulletBehaviourPrefab;

	[SerializeField]
	private int _initialSize = 1;

	[SerializeField]
	private int _maxSize = 3;

	[SerializeField]
	private bool _collectionChecks = true;

	private IObjectPool<BulletBehaviour> _pool;

	private void InitializePool()
	{
		_pool = new ObjectPool<BulletBehaviour>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, _collectionChecks, _initialSize, _maxSize);
	}

	private BulletBehaviour CreatePooledItem()
	{
		return Instantiate(_bulletBehaviourPrefab);
	}

	private void OnReturnedToPool(BulletBehaviour behaviour)
	{
		behaviour.gameObject.SetActive(false);
		behaviour.transform.SetParent(this.transform);
	}

	private void OnTakeFromPool(BulletBehaviour behaviour)
	{
		behaviour.gameObject.SetActive(true);
		behaviour.transform.SetParent(null);
	}

	private void OnDestroyPoolObject(BulletBehaviour behaviour)
	{
		behaviour.gameObject.SetActive(false);
		behaviour.transform.SetParent(this.transform);
	}

	public BulletBehaviour GetBehaviour()
	{
		if (_pool == null)
		{
			InitializePool();
		}

		return _pool.Get();
	}

	public void Release(BulletBehaviour bullet)
	{
		_pool.Release(bullet);
	}
}
