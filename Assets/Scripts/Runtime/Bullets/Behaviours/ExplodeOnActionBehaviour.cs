using UnityEngine;
using UnityEngine.InputSystem;

public class ExplodeOnActionBehaviour : BulletBehaviour
{
	[SerializeField]
	private PlayerData _playerData;

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
				hitable.Hit(_playerData.GetBaseHitData());
			}
		}
	}

	private void OnDisable()
	{
		_explodeActionReference.action.performed -= OnActionPerformed;
	}
}
