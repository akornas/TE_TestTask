using UnityEngine;

public class InvokeEventOnHit : AbstractOnHit
{
	[SerializeField]
	private ScriptableEventData _eventData;

	protected override void OnTakeHit(HitData hitData)
	{
		_eventData.Invoke();
	}
}
