using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	private Transform _behavioursRoot;
	private BulletPool _bulletPool;
	private readonly List<BulletBehaviour> _behaviours = new();

	public void Initialize(BulletPool bulletPool)
	{
		_bulletPool = bulletPool;
	}

	public void AddBehaviour(BulletBehaviour bulletBehaviour)
	{
		bulletBehaviour.transform.SetParent(_behavioursRoot);
		_behaviours.Add(bulletBehaviour);
	}

	public void BackToPool()
	{
		_bulletPool.Release(this);
	}

	private void OnCollisionEnter(Collision collision)
	{
		BackToPool();
		HandleBehaviours();
		HandleHitable(collision);
	}

	private void HandleBehaviours()
	{
		foreach (var behaviour in _behaviours)
		{
			behaviour.ActionOnHit();
		}
	}

	private void HandleHitable(Collision collision)
	{
		if (collision.gameObject.TryGetComponent<IHitable>(out var hitable))
		{
			hitable.Hit(null);
		}
	}
}
