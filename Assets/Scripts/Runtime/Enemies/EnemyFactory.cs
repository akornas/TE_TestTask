using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractEnemyFactory
{
	[SerializeField]
	private List<EnemyData> _enemies;

	[SerializeField]
	private List<int> _percentageSpawnChance = new();

	private void OnEnable()
	{
		FillPercentageSpawnChanceList();
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
				var enemy = Instantiate(_enemies[i].Prefab);
				enemy.Initialize(_enemies[i]);
				return Instantiate(_enemies[i].Prefab);
			}
		}

		return null;
	}
}
