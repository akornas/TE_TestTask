using UnityEngine;

public class CooldownManager : MonoBehaviour
{
	public event System.Action OnRefreshSkillOnCooldownEvent;

	[SerializeField]
	private PlayerData _playerData;

	private SkillData _skillOnCooldown;
	private float _currentCooldownTime;

	public float CurrentCooldownTime => _currentCooldownTime;
	public SkillData CurrentSkillOnCooldown => _skillOnCooldown;

	public bool IsSkillOnCooldown(SkillScriptableEnum skillEnum)
	{
		return _skillOnCooldown == null || !_skillOnCooldown.Enum.Equals(skillEnum);
	}

	public void AddSkillCooldown(SkillData skillData)
	{
		_skillOnCooldown = skillData;
		_currentCooldownTime = _skillOnCooldown.Cooldown.ValuePerLevel(_playerData.GameplayData.Level);
	}

	private void Update()
	{
		if (_skillOnCooldown == null)
		{
			return;
		}

		UpdateCounter();
		OnRefreshSkillOnCooldownEvent?.Invoke();
	}

	private void UpdateCounter()
	{
		_currentCooldownTime -= Time.deltaTime;

		if (_currentCooldownTime <= 0)
		{
			_skillOnCooldown = null;
		}
	}
}
