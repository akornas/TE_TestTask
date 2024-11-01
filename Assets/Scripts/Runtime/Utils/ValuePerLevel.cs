using System;
using UnityEngine;

public abstract class AbstractValuePerLevel<T>
{
	[SerializeField]
	private T[] _valuePerLevel;

	public T ValuePerLevel(int level)
	{
		return level < _valuePerLevel.Length ?
			_valuePerLevel[level] :
			_valuePerLevel[_valuePerLevel.Length - 1];
	}
}

[Serializable]
public class FloatPerLevel : AbstractValuePerLevel<float>
{
}

[Serializable]
public class IntPerLevel : AbstractValuePerLevel<int>
{
}
