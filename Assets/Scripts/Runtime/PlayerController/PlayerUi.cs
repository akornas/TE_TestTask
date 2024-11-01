using TMPro;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private TextMeshProUGUI _scoreValuelabel;

	[SerializeField]
	private TextMeshProUGUI _levelValuelabel;

	[SerializeField]
	private TextMeshProUGUI _healthValuelabel;

	private void OnEnable()
	{
		_playerData.GameplayData.OnDataChangedEvent += OnDataChanged;
		OnDataChanged();
	}

	private void OnDataChanged()
	{
		_scoreValuelabel.text = $"{_playerData.GameplayData.Score}";
		_levelValuelabel.text = $"{_playerData.GameplayData.Level + 1}";
		_healthValuelabel.text = $"{_playerData.GameplayData.Health}";
	}

	private void OnDisable()
	{
		_playerData.GameplayData.OnDataChangedEvent -= OnDataChanged;
	}
}
