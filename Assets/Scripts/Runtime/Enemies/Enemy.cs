using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private Damageable _damageable;

	[SerializeField]
	private MoveRootOnUpdate _moveRootOnUpdate;

	[SerializeField]
	private ScriptableEventWithEnemyData _eventWithEnemyData;

	[SerializeField]
	private Renderer _renderer;

	private EnemyData _data;

	public void Initialize(EnemyData data)
	{
		_data = data;

		_damageable.SetupHealth(_data.Health);
		_moveRootOnUpdate.SetSpeedMultiplier(_data.SpeedMultiplier);
		_damageable.OnDeathEvent += OnDeath;
		_renderer.material.color = ColorHelper.GetRandomColor();
	}

	private void OnDeath()
	{
		_eventWithEnemyData?.Invoke(_data);
	}

	private void OnTriggerEnter(Collider other)
	{
		_damageable.OnDeathEvent -= OnDeath;

		InvokeEvents();
		BackToPool();
	}

	private void InvokeEvents()
	{
		foreach (var @event in _data.AttackPlayerEvents)
		{
			@event.Invoke();
		}
	}

	private void BackToPool()
	{
		Destroy(this.gameObject);
	}
}
