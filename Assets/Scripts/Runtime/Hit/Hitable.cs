using UnityEngine;

public class Hitable : MonoBehaviour, IHitable
{
	public void Hit(HitData hitData)
	{
		Debug.Log(this.gameObject.name);
	}
}
