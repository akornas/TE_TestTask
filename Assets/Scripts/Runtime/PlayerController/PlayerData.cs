using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "TE/Player/Data", order = 1)]
public class PlayerData : ScriptableObject
{
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

	private HitData _baseHitData;

	public HitData GetBaseHitData()
	{
		TryBaseCreateHitData();
		return _baseHitData;
	}

	private void TryBaseCreateHitData()
	{
		if (_baseHitData.Damage != Damage.ValuePerLevel(GameplayData.Level))
		{
			_baseHitData = new HitData(Damage.ValuePerLevel(GameplayData.Level));
		}
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
			LevelUp();
		}
	}

	private void LevelUp()
	{
		GameplayData.Level += 1;
		TryBaseCreateHitData();
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
	private int _maxHealth = 0;

	private int _score = 0;
	private int _xp = 0;
	private int _level = 0;
	private int _health = 0;

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

	public int Health
	{
		get => _health;
		set
		{
			if (_health != value)
			{
				_health = value;
				OnDataChangedEvent?.Invoke();
			}
		}
	}

	public void Initialize()
	{
		SetDefaultValues();
	}

	public void Clear()
	{
		SetDefaultValues();
	}

	private void SetDefaultValues()
	{
		_score = 0;
		_xp = 0;
		_level = 0;
		_health = _maxHealth;
	}
}
