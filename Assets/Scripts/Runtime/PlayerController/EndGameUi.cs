using System;
using TMPro;
using UnityEngine;

public class EndGameUi : MonoBehaviour
{
	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private TextMeshProUGUI _scoreLabel;

	private Action _onRestartGameAction;

	private void OnEnable()
	{
		_scoreLabel.text = $"{_playerData.GameplayData.Score}";
	}

	public void AssignRestartAction(Action action)
	{
		_onRestartGameAction = action;
	}

	public void OnRestartGameButton()
	{
		_onRestartGameAction?.Invoke();
	}
}
