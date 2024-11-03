using TMPro;
using UnityEngine;

public class EnemyUi : MonoBehaviour
{
	[SerializeField]
	private Damageable _damageable;

	[SerializeField]
	private MoveRootOnUpdate _moveRootOnUpdate;

	[SerializeField]
	private TextMeshPro _healthLabel;

	[SerializeField]
	private TextMeshPro _speedLabel;

	private void OnEnable()
	{
		_damageable.OnChangeHealthEvent += OnChangeHealth;
		_moveRootOnUpdate.OnChangeSpeedEvent += OnChangeSpeed;

		OnChangeHealth();
		OnChangeSpeed();
	}

	private void OnChangeHealth()
	{
		_healthLabel.text = $"{_damageable.Health:F1}/{_damageable.MaxHealth:F1}";
	}

	private void OnChangeSpeed()
	{
		_speedLabel.text = $"{_moveRootOnUpdate.Speed:F1}";
	}

	private void OnDisable()
	{
		_damageable.OnChangeHealthEvent -= OnChangeHealth;
		_moveRootOnUpdate.OnChangeSpeedEvent -= OnChangeSpeed;
	}
}
