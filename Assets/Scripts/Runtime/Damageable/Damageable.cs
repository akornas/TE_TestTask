using UnityEngine;

public class Damageable : MonoBehaviour
{
	public event System.Action OnDeathEvent;

	[SerializeField]
	private GameObject _root;

	[SerializeField]
	private Hitable _hitable;

	[SerializeField]
	private int _health;

	private void OnEnable()
	{
		_hitable.OnHitEvent += OnTakeHit;
	}

	private void OnTakeHit(HitData hitData)
	{
		_health -= hitData.Damage;

		CheckDeath();
	}

	private void CheckDeath()
	{
		if (_health <= 0)
		{
			OnDeathEvent?.Invoke();
			Destroy(_root);
		}
	}

	private void OnDisable()
	{
		_hitable.OnHitEvent -= OnTakeHit;
	}
}
