using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "TE/Player/Data", order = 1)]
public class PlayerData : ScriptableObject
{
	[field: SerializeField]
	public float Health { get; private set; }

	[field: SerializeField]
	public float MoveSpeed { get; private set; }

	[field: SerializeField]
	public float ShootDelay { get; private set; }

}
