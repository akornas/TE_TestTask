using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool
{
	private readonly Enemy _prefab;
	private readonly IObjectPool<Enemy> _pool;

	public EnemyPool(Enemy prefab)
	{
		_prefab = prefab;
		_pool = new ObjectPool<Enemy>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject);
	}

	private Enemy CreatePooledItem()
	{
		var createdEnemy = Object.Instantiate(_prefab);
		return createdEnemy;
	}

	private void OnReturnedToPool(Enemy enemy)
	{
		enemy.gameObject.SetActive(false);
	}

	private void OnTakeFromPool(Enemy enemy)
	{
		enemy.gameObject.SetActive(true);
	}

	private void OnDestroyPoolObject(Enemy enemy)
	{
		enemy.gameObject.SetActive(false);
	}

	public Enemy Get()
	{
		return _pool.Get();
	}

	public void Release(Enemy enemy)
	{
		_pool.Release(enemy);
	}
}
