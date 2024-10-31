using UnityEngine;
using UnityEngine.InputSystem;

public class ExplodeOnActionBehaviour : BulletBehaviour
{
	[SerializeField]
	private InputActionReference _explodeActionReference;

	private void OnEnable()
	{
		_explodeActionReference.action.performed += OnActionPerformed;
	}

	private void OnActionPerformed(InputAction.CallbackContext obj)
	{
		ExplosionDamage();
		Release();
	}

	private void ExplosionDamage()
	{
		var hitColliders = Physics.OverlapSphere(this.transform.position, 5);

		foreach (var hitCollider in hitColliders)
		{
			if (hitCollider.TryGetComponent<IHitable>(out var hitable))
			{
				hitable.Hit(new HitData(1));
			}
		}
	}

	private void OnDisable()
	{
		_explodeActionReference.action.performed -= OnActionPerformed;
	}
}
