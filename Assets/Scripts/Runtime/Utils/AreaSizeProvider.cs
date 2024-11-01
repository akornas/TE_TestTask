using UnityEngine;

public class AreaSizeProvider : MonoBehaviour
{
	[SerializeField]
	private Renderer _renderer;

	private Vector2 _areaWidthInWorldSpace;
	private Vector2 _areaDeepthInWorldSpace;

	public Vector2 AreaWidthInWorldSpace => _areaWidthInWorldSpace;
	public Vector2 AreaDeepthInWorldSpace => _areaDeepthInWorldSpace;

	private void Start()
	{
		var bounds = _renderer.bounds;

		_areaWidthInWorldSpace = new Vector2(bounds.min.x, bounds.max.x);
		_areaDeepthInWorldSpace = new Vector2(bounds.min.z, bounds.max.z);
	}
}
