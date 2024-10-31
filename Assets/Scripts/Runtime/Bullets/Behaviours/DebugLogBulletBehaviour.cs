using UnityEngine;

public class DebugLogBulletBehaviour : BulletBehaviour
{
	[SerializeField]
	private string _message;

	protected override void InternalActionOnHit()
	{
		Debug.Log(_message);
	}
}
