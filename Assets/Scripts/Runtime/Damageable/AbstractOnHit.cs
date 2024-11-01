using UnityEngine;

public abstract class AbstractOnHit : MonoBehaviour
{
	[SerializeField]
	private Hitable _hitable;

	private void OnEnable()
	{
		_hitable.OnHitEvent += OnTakeHit;
		InternalOnEnable();
	}

	protected virtual void InternalOnEnable() { }

	protected abstract void OnTakeHit(HitData hitData);

	private void OnDisable()
	{
		_hitable.OnHitEvent -= OnTakeHit;
		InternalOnDisable();
	}

	protected virtual void InternalOnDisable() { }

}
