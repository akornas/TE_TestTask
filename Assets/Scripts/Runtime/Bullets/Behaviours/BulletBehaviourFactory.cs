using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletBehaviourFactory : MonoBehaviour
{
	[SerializeField]
	private List<ScriptableEnumBehaviourPoolPair> _behaviourPoolsLookUp;

	public BulletBehaviour GetBehaviourFor(SkillScriptableEnum skillEnum)
	{
		var enumBehaviourPoolPair = _behaviourPoolsLookUp.FirstOrDefault(pair => pair.SkillEnum.Equals(skillEnum));

		if (enumBehaviourPoolPair != null)
		{
			var behaviour = enumBehaviourPoolPair.BulletBehaviourPool.GetBehaviour();
			behaviour.Initialize(enumBehaviourPoolPair.BulletBehaviourPool);

			return behaviour;
		}

		return null;
	}
}

[Serializable]
public class ScriptableEnumBehaviourPoolPair
{
	public SkillScriptableEnum SkillEnum;
	public BulletBehaviourPool BulletBehaviourPool;
}
