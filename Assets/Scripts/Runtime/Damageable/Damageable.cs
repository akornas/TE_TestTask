using UnityEngine;

public class Damageable : MonoBehaviour
{
	public event System.Action OnDeathEvent;
	public event System.Action OnChangeHealthEvent;

	[SerializeField]
	private GameObject _root;

	[SerializeField]
	private Hitable _hitable;

	[SerializeField]
	private float _health;

	private float _maxHealth;

	public float Health => _health;
	public float MaxHealth => _maxHealth;

	private void OnEnable()
	{
		_hitable.OnHitEvent += OnTakeHit;
	}

	public void SetupHealth(float health)
	{
		_maxHealth = health;
		_health = _maxHealth;
		OnChangeHealthEvent?.Invoke();
	}

	public void AddMaxHealth(float value)
	{
		_maxHealth += value;
		_health += value;
		OnChangeHealthEvent?.Invoke();
	}

	private void OnTakeHit(HitData hitData)
	{
		_health -= hitData.Damage;
		OnChangeHealthEvent?.Invoke();

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
