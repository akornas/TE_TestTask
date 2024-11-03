using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractEnemyFactory
{
	[SerializeField]
	private List<EnemyData> _enemies;

	[SerializeField]
	private List<int> _percentageSpawnProbability = new();
	private readonly Dictionary<EnemyData, EnemyPool> _enemyPools = new();

	private void OnEnable()
	{
		CreateEnemyPools();
		FillPercentageSpawnProbabilityList();
	}

	private void CreateEnemyPools()
	{
		for (int i = 0; i < _enemies.Count; i++)
		{
			var pool = new EnemyPool(_enemies[i].Prefab);
			_enemyPools.Add(_enemies[i], pool);
		}
	}

	private void FillPercentageSpawnProbabilityList()
	{
		int previousSpawnProbabilities = 0;
		for (int i = 0; i < _enemies.Count; i++)
		{
			_percentageSpawnProbability.Add(previousSpawnProbabilities + _enemies[i].SpawnProbability);
			previousSpawnProbabilities += _enemies[i].SpawnProbability;
		}
	}

	public override Enemy Create()
	{
		var poolIndex = FindPoolIndex();
		var pool = GetPool(poolIndex);
		var enemy = InitializeEnemy(_enemies[poolIndex], pool);

		return enemy;
	}

	private int FindPoolIndex()
	{
		var randomNumber = Random.Range(0, 100);

		for (int i = 0; i < _percentageSpawnProbability.Count; i++)
		{
			if (randomNumber < _percentageSpawnProbability[i])
			{
				return i;
			}
		}

		return 0;
	}

	private EnemyPool GetPool(int poolIndex)
	{
		return _enemyPools[_enemies[poolIndex]];
	}

	private Enemy InitializeEnemy(EnemyData data, EnemyPool pool)
	{
		var enemy = pool.Get();
		enemy.Initialize(data, pool);
		enemy.transform.SetParent(this.transform);

		return enemy;
	}
}
