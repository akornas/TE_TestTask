using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
	[SerializeField]
	private Hitable _hitable;

	[SerializeField]
	private Renderer _renderer;

	[SerializeField]
	private Material _hitMaterial;

	[SerializeField]
	private float _blinkTime = 0.4f;

	private Material _cachedMaterial;

	private void OnEnable()
	{
		_hitable.OnHitEvent += OnTakeHit;
		_cachedMaterial = _renderer.material;
	}

	private void OnTakeHit(HitData hitData)
	{
		StartCoroutine(BlinkCoroutine());
	}

	private IEnumerator BlinkCoroutine()
	{
		_renderer.material = _hitMaterial;
		yield return new WaitForSeconds(_blinkTime);
		_renderer.material = _cachedMaterial;
	}

	private void OnDisable()
	{
		_hitable.OnHitEvent -= OnTakeHit;
	}
}
