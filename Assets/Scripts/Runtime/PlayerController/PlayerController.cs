using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private InputController _inputController;

	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private Transform _root;

	private void OnEnable()
	{
		_inputController.OnMoveEvent += OnMove;
	}

	private void OnMove(Vector2 moveVector)
	{
		var position = _root.transform.localPosition;
		position.x += moveVector.x * _playerData.MoveSpeed * Time.deltaTime;
		_root.transform.localPosition = position;
	}

	private void OnDisable()
	{
		_inputController.OnMoveEvent -= OnMove;
	}
}
