using UnityEngine;

public class DebugLogOnEvent : AbstractOnEvent
{
	[SerializeField]
	private string _message;

	protected override void InternalOnEventHandler()
	{
		Debug.Log(_message);
	}
}
