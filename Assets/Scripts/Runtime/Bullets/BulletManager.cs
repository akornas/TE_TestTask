using UnityEngine;

public class BulletManager : MonoBehaviour
{
	[SerializeField]
	private InputController _inputController;

	[SerializeField]
	private BulletPool _bulletPool;

	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private Transform _spawnPlace;

	private float _lastShootTime;

	private void OnEnable()
	{
		InitializePool();
		_inputController.OnShootEvent += OnShoot;
		_inputController.OnUseSkillEvent += OnUseSkill;
	}

	private void InitializePool()
	{
		_bulletPool.InitializePool();
	}

	private void OnShoot()
	{
		if (CanShoot())
		{
			_lastShootTime = Time.timeSinceLevelLoad;
			var bullet = _bulletPool.GetBullet();
			bullet.transform.position = _spawnPlace.position;
		}
	}

	private bool CanShoot()
	{
		return Time.timeSinceLevelLoad - _lastShootTime > _playerData.ShootDelay;
	}

	private void OnUseSkill()
	{
	}

	private void OnDisable()
	{
		_inputController.OnShootEvent -= OnShoot;
		_inputController.OnUseSkillEvent -= OnUseSkill;
	}
}
