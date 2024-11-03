using UnityEngine;

public class ChangeSpeedOnEvent : AbstractOnEvent
{
	[SerializeField]
	private MoveRootOnUpdate _moveRootOnUpdate;

	[SerializeField]
	private float _speedPercentageMultiplier = 10;

	protected override void InternalOnEventHandler()
	{
		var boostValue = _speedPercentageMultiplier / 100f;
		_moveRootOnUpdate.AddSpeedBoost(boostValue);
	}
}
