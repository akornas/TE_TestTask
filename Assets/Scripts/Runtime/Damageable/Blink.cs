using System.Collections;
using UnityEngine;

public class Blink : AbstractOnHit
{
	[SerializeField]
	private Renderer _renderer;

	[SerializeField]
	private Material _hitMaterial;

	[SerializeField]
	private float _blinkTime = 0.4f;

	private Material _cachedMaterial;

	protected override void InternalOnEnable()
	{
		_cachedMaterial = _renderer.material;
	}

	protected override void OnTakeHit(HitData hitData)
	{
		StartCoroutine(BlinkCoroutine());
	}

	private IEnumerator BlinkCoroutine()
	{
		_renderer.material = _hitMaterial;
		yield return new WaitForSeconds(_blinkTime);
		_renderer.material = _cachedMaterial;
	}
}
