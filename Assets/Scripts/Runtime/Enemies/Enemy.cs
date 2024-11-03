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
	private EnemyPool _pool;

	public void Initialize(EnemyData data, EnemyPool pool)
	{
		_data = data;
		_pool = pool;

		_damageable.SetupHealth(_data.Health);
		_moveRootOnUpdate.InitializeSpeed(_data.SpeedMultiplier);
		_damageable.OnDamagedEvent += OnDeath;
		_renderer.material.color = ColorHelper.GetRandomColor();
	}

	private void OnDeath()
	{
		_eventWithEnemyData?.Invoke(_data);
	}

	private void OnTriggerEnter(Collider other)
	{
		_damageable.OnDamagedEvent -= OnDeath;

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
		_pool.Release(this);
	}
}
