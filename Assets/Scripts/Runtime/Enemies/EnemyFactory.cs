using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractEnemyFactory
{
	[SerializeField]
	private List<EnemyData> _enemies;

	[SerializeField]
	private List<int> _percentageSpawnChance = new();
	private readonly Dictionary<EnemyData, EnemyPool> _enemyPools = new();

	private void OnEnable()
	{
		CreateEnemyPools();
		FillPercentageSpawnChanceList();
	}

	private void CreateEnemyPools()
	{
		for (int i = 0; i < _enemies.Count; i++)
		{
			var pool = new EnemyPool(_enemies[i].Prefab);
			_enemyPools.Add(_enemies[i], pool);
		}
	}

	private void FillPercentageSpawnChanceList()
	{
		int previousSpawnChances = 0;
		for (int i = 0; i < _enemies.Count; i++)
		{
			_percentageSpawnChance.Add(previousSpawnChances + _enemies[i].SpawnChance);
			previousSpawnChances += _enemies[i].SpawnChance;
		}
	}

	public override Enemy Create()
	{
		var randomNumber = Random.Range(0, 100);

		for (int i = 0; i < _percentageSpawnChance.Count; i++)
		{
			if (randomNumber < _percentageSpawnChance[i])
			{
				var pool = _enemyPools[_enemies[i]];
				var enemy = pool.Get();

				enemy.Initialize(_enemies[i], pool);
				enemy.transform.SetParent(this.transform);
				return enemy;
			}
		}

		return null;
	}
}
