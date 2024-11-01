using System.Collections.Generic;
using UnityEngine;

public class DebugEnemyFactory : AbstractEnemyFactory
{
	[SerializeField]
	private List<EnemyData> _enemies;

	private int _lastSpawnedEnemyIndex = 0;

	public override Enemy Create()
	{
		var enemy = Instantiate(_enemies[_lastSpawnedEnemyIndex].Prefab);
		enemy.Initialize(_enemies[_lastSpawnedEnemyIndex]);
		_lastSpawnedEnemyIndex++;
		_lastSpawnedEnemyIndex = Mathf.Clamp(_lastSpawnedEnemyIndex, 0, _enemies.Count - 1);
		return enemy;
	}
}
