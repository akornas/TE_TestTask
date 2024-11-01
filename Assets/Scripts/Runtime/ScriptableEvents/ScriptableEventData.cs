using UnityEngine;

public abstract class ScriptableEventData : ScriptableObject
{
	public event System.Action OnEvent;

	public void Invoke()
	{
		OnEvent?.Invoke();
	}
}

public abstract class ScriptableEventDataWithValue<T> : ScriptableObject
{
	public event System.Action<T> OnEvent;

	public void Invoke(T value)
	{
		OnEvent?.Invoke(value);
	}
}
