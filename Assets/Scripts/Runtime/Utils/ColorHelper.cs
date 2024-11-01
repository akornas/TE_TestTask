using UnityEngine;

public static class ColorHelper
{
	public static Color GetRandomColor()
	{
		return new Color(GetRandomValue(), GetRandomValue(), GetRandomValue());
	}

	private static float GetRandomValue()
	{
		return Random.Range(0f, 1f);
	}
}
