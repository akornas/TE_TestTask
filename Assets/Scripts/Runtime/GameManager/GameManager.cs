using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private PlayerData _playerData;

	private void OnEnable()
	{
		InitializeGame();
	}

	private void InitializeGame()
	{
		_playerData.GameplayData.Initialize();
	}
}
