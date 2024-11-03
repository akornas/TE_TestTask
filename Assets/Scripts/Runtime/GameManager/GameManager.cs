using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private const string END_GAME_UI_ADDRESS = "EndGameUi";

	[SerializeField]
	private AddressableManager _addressableManager;

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
		TimeManager.PauseTime();
		_addressableManager.Load(END_GAME_UI_ADDRESS, OnUiLoaded);
	}

	private void OnUiLoaded(GameObject loadedObject)
	{
		if (loadedObject.TryGetComponent<EndGameUi>(out var endGameUi))
		{
			endGameUi.AssignRestartAction(RestartGame);
		}
	}

	private void InitializeGame()
	{
		_playerData.GameplayData.Initialize();
	}

	public void RestartGame()
	{
		TimeManager.ResumeTime();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void OnDestroy()
	{
		_playerController.OnPlayerDeathEvent -= OnEndGame;
		_playerData.GameplayData.Clear();
	}
}
