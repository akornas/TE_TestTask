using UnityEngine;

public abstract class AbstractOnEvent : MonoBehaviour
{
	[SerializeField]
	private ScriptableEventData _eventData;

	private void OnEnable()
	{
		_eventData.OnEvent += OnEventHandler;
	}

	private void OnEventHandler()
	{
		InternalOnEventHandler();
	}

	protected abstract void InternalOnEventHandler();

	private void OnDisable()
	{
		_eventData.OnEvent -= OnEventHandler;
	}
}
