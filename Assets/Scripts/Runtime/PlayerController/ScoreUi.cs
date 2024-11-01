using TMPro;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private TextMeshProUGUI _scoreValuelabel;

	private void OnEnable()
	{
		_playerData.GameplayData.OnDataChangedEvent += OnDataChanged;
		OnDataChanged();
	}

	private void OnDataChanged()
	{
		_scoreValuelabel.text = $"{_playerData.GameplayData.Score}";
	}

	private void OnDisable()
	{
		_playerData.GameplayData.OnDataChangedEvent -= OnDataChanged;
	}
}
