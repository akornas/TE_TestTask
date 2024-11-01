using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private PlayerController _playerController;

	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private EndGameUi _endGameUi;

	private void OnEnable()
	{
		_playerController.OnPlayerDeathEvent += OnEndGame;
		InitializeGame();
	}

	private void OnEndGame()
	{
		Time.timeScale = 0;
		_endGameUi.SetActive();
	}

	private void InitializeGame()
	{
		_playerData.GameplayData.Initialize();
	}

	public void ReloadGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void OnDestroy()
	{
		_playerController.OnPlayerDeathEvent -= OnEndGame;
		_playerData.GameplayData.Clear();
	}
}
