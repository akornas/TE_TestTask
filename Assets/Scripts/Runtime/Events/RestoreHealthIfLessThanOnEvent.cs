using UnityEngine;

public class RestoreHealthIfLessThanOnEvent : AbstractOnEvent
{
	[SerializeField]
	private Damageable _damageable;

	[SerializeField]
	[Range(0, 100)]
	private int _healthThresholdPercentage = 50;

	protected override void InternalOnEventHandler()
	{
		if (CanRestoreHealth())
		{
			_damageable.SetupHealth(_damageable.MaxHealth);
		}
	}

	private bool CanRestoreHealth()
	{
		return _damageable.Health < _damageable.MaxHealth * _healthThresholdPercentage / 100;
	}
}
