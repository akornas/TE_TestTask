using UnityEngine;

public class AddMaxHealthOnEvent : AbstractOnEvent
{
	[SerializeField]
	private Damageable _damageable;

	[SerializeField]
	[Min(1)]
	private float _healthPercentageToAdd = 10;

	protected override void InternalOnEventHandler()
	{
		var valueToAdd = _damageable.MaxHealth * _healthPercentageToAdd / 100f;
		_damageable.AddMaxHealth(valueToAdd);
	}
}
