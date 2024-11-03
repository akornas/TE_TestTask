using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "TE/Enemies/Data")]
public class EnemyData : ScriptableObject
{
	[field: SerializeField]
	public int SpawnProbability { get; private set; }

	[field: SerializeField]
	public float SpeedMultiplier { get; private set; }

	[field: SerializeField]
	public float Health { get; private set; }

	[field: SerializeField]
	public int Score { get; private set; }

	[field: SerializeField]
	public int Xp { get; private set; }

	[field: SerializeField]
	public Enemy Prefab { get; private set; }

	[field: SerializeField]
	public List<EnemyEventData> AttackPlayerEvents { get; private set; }
}
