using UnityEngine;

public abstract class ScriptableEventData : ScriptableObject
{
	public event System.Action OnEvent;

	public void Invoke()
	{
		OnEvent?.Invoke();
	}
}
