using UnityEngine;

public class BulletMove : MonoBehaviour
{
	[SerializeField]
	private Transform _root;

	[SerializeField]
	private float _speed;

	private void Update()
	{
		if (!CanMove())
		{
			return;
		}

		_root.transform.localPosition += Vector3.forward * _speed * Time.deltaTime;
	}

	private bool CanMove()
	{
		return _root != null;
	}
}
