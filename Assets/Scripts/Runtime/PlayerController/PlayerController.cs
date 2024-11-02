using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public event System.Action OnPlayerDeathEvent;

	[SerializeField]
	private InputController _inputController;

	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private Transform _root;

	[SerializeField]
	private ScriptableEventWithEnemyData _eventWithEnemyData;

	[SerializeField]
	private List<EnemyEventData> _enemyAttackEventDatas;

	[SerializeField]
	private AreaBoundsProvider _areaSizeProvider;

	private void OnEnable()
	{
		_inputController.OnMoveEvent += OnMove;
		_eventWithEnemyData.OnEvent += OnEnemyKilled;

		foreach (var enemyEvent in _enemyAttackEventDatas)
		{
			enemyEvent.OnEvent += OnEnemyAttack;
		}
	}

	private void OnEnemyKilled(EnemyData obj)
	{
		_playerData.AddXp(obj.Xp);
		_playerData.GameplayData.Score += obj.Score;
	}

	private void OnEnemyAttack()
	{
		_playerData.GameplayData.Health -= 1;

		CheckDeath();
	}

	private void CheckDeath()
	{
		if (_playerData.GameplayData.Health <= 0)
		{
			OnPlayerDeathEvent?.Invoke();
		}
	}

	private void OnMove(Vector2 moveVector)
	{
		var position = _root.transform.localPosition;
		position.x += moveVector.x * _playerData.MoveSpeed * Time.deltaTime;

		if (position.x > _areaSizeProvider.WidthInWorldSpace.x && position.x < _areaSizeProvider.WidthInWorldSpace.y)
		{
			_root.transform.localPosition = position;
		}
	}

	private void OnDisable()
	{
		_inputController.OnMoveEvent -= OnMove;
		_eventWithEnemyData.OnEvent -= OnEnemyKilled;

		foreach (var enemyEvent in _enemyAttackEventDatas)
		{
			enemyEvent.OnEvent -= OnEnemyAttack;
		}
	}
}
