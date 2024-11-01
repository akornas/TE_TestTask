using System;
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

	[field: SerializeField]
	public FloatPerLevel Damage { get; private set; }

	[field: SerializeField]
	public SkillData SkillData { get; private set; }

	[field: SerializeField]
	public IntPerLevel XpNeededForLevel { get; private set; }

	[field: SerializeField]
	public GameplayPlayerData GameplayData { get; private set; }

	public HitData GetBaseHitData()
	{
		return new HitData(Damage.ValuePerLevel(GameplayData.Level));
	}

	public void AddXp(int value)
	{
		GameplayData.Xp += value;
		CheckPlayerLevelUp();
	}

	private void CheckPlayerLevelUp()
	{
		if (CanLevelUp())
		{
			GameplayData.Level += 1;
		}
	}

	private bool CanLevelUp()
	{
		return GameplayData.Xp >= XpNeededForLevel.ValuePerLevel(GameplayData.Level + 1) &&
			GameplayData.Level < XpNeededForLevel.MaxLevel;
	}
}

[Serializable]
public class GameplayPlayerData
{
	public event System.Action OnDataChangedEvent;

	[SerializeField]
	private int _score = 0;

	[SerializeField]
	private int _xp = 0;

	[SerializeField]
	private int _level = 0;

	public int Score
	{
		get => _score;
		set
		{
			if (_score != value)
			{
				_score = value;
				OnDataChangedEvent?.Invoke();
			}
		}
	}

	public int Xp
	{
		get => _xp;
		set
		{
			if (_xp != value)
			{
				_xp = value;
				OnDataChangedEvent?.Invoke();
			}
		}
	}

	public int Level
	{
		get => _level;
		set
		{
			if (_level != value)
			{
				_level = value;
				OnDataChangedEvent?.Invoke();
			}
		}
	}

	public void Initialize()
	{
		_score = 0;
		_xp = 0;
		_level = 0;
	}
}
