using UnityEngine;

public class ChangeSpeedOnEvent : AbstractOnEvent
{
	[SerializeField]
	private MoveRootOnUpdate _moveRootOnUpdate;

	[SerializeField]
	private float _speedPercentageMultiplier = 10;

	protected override void InternalOnEventHandler()
	{
		var valueToAdd = _moveRootOnUpdate.Speed * _speedPercentageMultiplier / 100f;
		_moveRootOnUpdate.AddSpeedMultiplier(valueToAdd);
	}
}
