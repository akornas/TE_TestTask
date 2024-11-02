using UnityEngine;

public class SkillsUi : MonoBehaviour
{
	[SerializeField]
	private CooldownManager _cooldownManager;

	[SerializeField]
	private SkillUi _skillUi;

	private void OnEnable()
	{
		OnRefreshSkillOnCooldown();
		_cooldownManager.OnRefreshSkillOnCooldownEvent += OnRefreshSkillOnCooldown;
	}

	private void OnRefreshSkillOnCooldown()
	{
		var shouldShowSkillUi = _cooldownManager.CurrentSkillOnCooldown != null;

		if (shouldShowSkillUi != _skillUi.gameObject.activeInHierarchy)
		{
			_skillUi.gameObject.SetActive(shouldShowSkillUi);
		}

		_skillUi.UpdateLabel(_cooldownManager.CurrentCooldownTime);
	}

	private void OnDisable()
	{
		_cooldownManager.OnRefreshSkillOnCooldownEvent -= OnRefreshSkillOnCooldown;
	}
}
