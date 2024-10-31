using TMPro;
using UnityEngine;

public class SkillUi : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _label;

	public void UpdateLabel(float value)
	{
		_label.text = $"{value:F1}";
	}
}
