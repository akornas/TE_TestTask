using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private AbstractEnemyFactory _enemyFactory;

	[SerializeField]
	private float _spawnDelay = 1;

	[SerializeField]
	private AreaSizeProvider _areaSizeProvider;

	private float _lastSpawnTime = 0;

	private void Awake()
	{
		_lastSpawnTime = _spawnDelay;
	}

	private void Update()
	{
		if (!CanSpawnEnemy())
		{
			return;
		}

		SpawnEnemy();
	}

	private bool CanSpawnEnemy()
	{
		return Time.timeSinceLevelLoad - _lastSpawnTime > _spawnDelay;
	}

	private void SpawnEnemy()
	{
		_lastSpawnTime = Time.timeSinceLevelLoad;
		var createdEnemy = _enemyFactory.Create();
		var posX = Random.Range(_areaSizeProvider.AreaWidthInWorldSpace.x, _areaSizeProvider.AreaWidthInWorldSpace.y);
		var posZ = _areaSizeProvider.AreaDeepthInWorldSpace.x;

		createdEnemy.transform.position = new Vector3(posX, 0, posZ);
	}

}
