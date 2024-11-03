using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	private Transform _behavioursRoot;

	private BulletPool _bulletPool;
	private readonly List<BulletBehaviour> _behaviours = new();
	private HitData _hitData;

	public void Initialize(BulletPool bulletPool)
	{
		_bulletPool = bulletPool;
	}

	public void SetHitData(HitData hitData)
	{
		_hitData = hitData;
	}

	public void AddBehaviour(BulletBehaviour bulletBehaviour)
	{
		bulletBehaviour.transform.SetParent(_behavioursRoot);
		bulletBehaviour.transform.localPosition = Vector3.zero;
		bulletBehaviour.OnReleasedEvent += OnReleasedBehaviour;

		_behaviours.Add(bulletBehaviour);
	}

	private void OnReleasedBehaviour(BulletBehaviour releasedBehaviour)
	{
		releasedBehaviour.OnReleasedEvent -= OnReleasedBehaviour;

		BackToPool();
		_behaviours.Remove(releasedBehaviour);
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
			behaviour.OnReleasedEvent -= OnReleasedBehaviour;
			behaviour.ActionOnHit();
		}

		_behaviours.Clear();
	}

	private void HandleHitable(Collision collision)
	{
		var hitable = collision.gameObject.GetComponentInChildren<IHitable>();
		if (hitable != null)
		{
			hitable.Hit(_hitData);
		}
	}
}
