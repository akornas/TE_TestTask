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
	private float _speedBoost = 1;

	public float Speed => _speed * _speedMultiplier * _speedBoost;

	public void InitializeSpeed(float multiplier)
	{
		_speedBoost = 1;
		_speedMultiplier = multiplier;
		OnChangeSpeedEvent?.Invoke();
	}

	public void AddSpeedBoost(float value)
	{
		_speedBoost += value;
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
