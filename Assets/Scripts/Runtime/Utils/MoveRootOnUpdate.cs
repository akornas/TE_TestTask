using UnityEngine;

public class MoveRootOnUpdate : MonoBehaviour
{
	public event System.Action OnChangeSpeedEvent;

	[SerializeField]
	private Transform _root;

	[SerializeField]
	private float _speed;

	[SerializeField]
	private Vector3 _direction = Vector3.forward;

	private float _speedMultiplier = 1;

	public float Speed => _speed * _speedMultiplier;

	public void SetSpeedMultiplier(float multiplier)
	{
		_speedMultiplier = multiplier;
		OnChangeSpeedEvent?.Invoke();
	}

	public void AddSpeedMultiplier(float valueToAdd)
	{
		_speedMultiplier += valueToAdd;
		OnChangeSpeedEvent?.Invoke();
	}

	private void Update()
	{
		if (!CanMove())
		{
			return;
		}

		_root.transform.localPosition += Speed * Time.deltaTime * _direction;
	}

	private bool CanMove()
	{
		return _root != null;
	}
}
