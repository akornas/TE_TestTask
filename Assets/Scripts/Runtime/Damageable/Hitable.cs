using UnityEngine;

public class Hitable : MonoBehaviour, IHitable
{
	public event System.Action<HitData> OnHitEvent;

	public void Hit(HitData hitData)
	{
		OnHitEvent?.Invoke(hitData);
	}
}
