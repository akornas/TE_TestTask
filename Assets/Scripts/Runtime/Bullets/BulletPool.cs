using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
	[SerializeField]
	private Bullet _bulletPrefab;

	[SerializeField]
	private int _initialSize = 10;

	[SerializeField]
	private int _maxSize = 20;

	[SerializeField]
	private bool _collectionChecks = true;

	private IObjectPool<Bullet> _pool;

	public void InitializePool()
	{
		_pool = new ObjectPool<Bullet>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, _collectionChecks, _initialSize, _maxSize);
	}

	private Bullet CreatePooledItem()
	{
		var createdBullet = Instantiate(_bulletPrefab);
		createdBullet.Initialize(this);
		createdBullet.transform.SetParent(this.transform);

		return createdBullet;
	}

	private void OnReturnedToPool(Bullet bullet)
	{
		bullet.gameObject.SetActive(false);
		bullet.transform.SetParent(this.transform);
	}

	private void OnTakeFromPool(Bullet bullet)
	{
		bullet.gameObject.SetActive(true);
		bullet.transform.SetParent(null);
	}

	private void OnDestroyPoolObject(Bullet bullet)
	{
		bullet.gameObject.SetActive(false);
		bullet.transform.SetParent(this.transform);
	}

	public Bullet GetBullet()
	{
		return _pool.Get();
	}

	public void Release(Bullet bullet)
	{
		_pool.Release(bullet);
	}
}
