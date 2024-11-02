using UnityEngine;
using UnityEngine.InputSystem;

public class ExplodeOnActionBehaviour : BulletBehaviour
{
	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private InputActionReference _explodeActionReference;

	[SerializeField]
	private float _radius = 5;

	[SerializeField]
	private GameObject _model;

	private void OnEnable()
	{
		HandleModel();
		_explodeActionReference.action.performed += OnActionPerformed;
	}

	private void HandleModel()
	{
		if (_model == null)
		{
			return;
		}

		_model.transform.localScale = Vector3.one * _radius * 2;
	}

	private void OnActionPerformed(InputAction.CallbackContext obj)
	{
		ExplosionDamage();
		Release();
	}

	private void ExplosionDamage()
	{
		var hitColliders = Physics.OverlapSphere(this.transform.position, _radius);

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
