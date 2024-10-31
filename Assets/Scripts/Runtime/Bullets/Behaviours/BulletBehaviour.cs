using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour
{
	public event System.Action<BulletBehaviour> OnReleasedEvent;

	private BulletBehaviourPool _cachedPool;

	public void Initialize(BulletBehaviourPool pool)
	{
		_cachedPool = pool;
	}

	public void ActionOnHit()
	{
		InternalActionOnHit();
		Release();
	}

	protected void Release()
	{
		_cachedPool.Release(this);
		OnReleasedEvent?.Invoke(this);
	}

	protected virtual void InternalActionOnHit() { }
}
