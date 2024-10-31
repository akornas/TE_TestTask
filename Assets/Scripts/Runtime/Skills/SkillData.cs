using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "TE/Skills/Data", order = 1)]
public class SkillData : ScriptableObject
{
	[field: SerializeField]
	public SkillScriptableEnum Enum { get; private set; }

	[field: SerializeField]
	public float Cooldown { get; private set; }
}
