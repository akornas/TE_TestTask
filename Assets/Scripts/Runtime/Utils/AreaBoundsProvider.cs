using UnityEngine;

public class AreaBoundsProvider : MonoBehaviour
{
	[SerializeField]
	private Renderer _renderer;

	public Vector2 WidthInWorldSpace { get; private set; }
	public Vector2 DeepthInWorldSpace { get; private set; }

	private void Start()
	{
		var bounds = _renderer.bounds;

		WidthInWorldSpace = new Vector2(bounds.min.x, bounds.max.x);
		DeepthInWorldSpace = new Vector2(bounds.min.z, bounds.max.z);
	}
}
