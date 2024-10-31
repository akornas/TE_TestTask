using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
	public event System.Action<Vector2> OnMoveEvent;
	public event System.Action OnShootEvent;
	public event System.Action OnUseSkillEvent;

	[SerializeField]
	private InputActionReference _moveActionReference;

	[SerializeField]
	private InputActionReference _shootActionReference;

	[SerializeField]
	private InputActionReference _skillActionReference;

	private InputAction MoveAction => _moveActionReference.action;
	private InputAction ShootAction => _shootActionReference.action;
	private InputAction SkillAction => _skillActionReference.action;

	private void Update()
	{
		if (MoveAction.IsPressed())
		{
			var moveActionValue = MoveAction.ReadValue<Vector2>();
			OnMoveEvent?.Invoke(moveActionValue);
		}

		if (ShootAction.WasPressedThisFrame())
		{
			OnShootEvent?.Invoke();
		}

		if (SkillAction.WasPressedThisFrame())
		{
			OnUseSkillEvent?.Invoke();
		}
	}
}
