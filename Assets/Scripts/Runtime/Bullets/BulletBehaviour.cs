using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour
{
	public event System.Action OnHitEvent;

	public void ActionOnHit()
	{
		InvokeOnHitEvent();
		InternalActionOnHit();
		Debug.Log("BackToPool");
		Destroy(this.gameObject);
	}

	protected virtual void InternalActionOnHit()
	{

	}

	protected void InvokeOnHitEvent()
	{
		OnHitEvent?.Invoke();
	}
}
