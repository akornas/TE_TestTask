using TMPro;
using UnityEngine;

public class EndGameUi : MonoBehaviour
{
	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private TextMeshProUGUI _scoreLabel;

	private void OnEnable()
	{
		_scoreLabel.text = $"{_playerData.GameplayData.Score}";
	}

	public void SetActive()
	{
		this.gameObject.SetActive(true);
	}
}
