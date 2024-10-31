using UnityEngine;

public class ShootingManager : MonoBehaviour
{
	[SerializeField]
	private CooldownManager _cooldownManager;

	[SerializeField]
	private InputController _inputController;

	[SerializeField]
	private BulletPool _bulletPool;

	[SerializeField]
	private BulletBehaviourFactory _bulletBehaviourFactory;

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
			bullet.SetHitData(_playerData.GetBaseHitData());
		}
	}

	private bool CanShoot()
	{
		return Time.timeSinceLevelLoad - _lastShootTime > _playerData.ShootDelay;
	}

	private void OnUseSkill()
	{
		if (_cooldownManager.CanUseSkill(_playerData.SkillData.Enum))
		{
			var bullet = _bulletPool.GetBullet();
			bullet.transform.position = _spawnPlace.position;
			bullet.SetHitData(_playerData.GetBaseHitData());

			var behaviour = _bulletBehaviourFactory.GetBehaviourFor(_playerData.SkillData.Enum);
			bullet.AddBehaviour(behaviour);
			_cooldownManager.AddSkillCooldown(_playerData.SkillData);
		}
	}

	private void OnDisable()
	{
		_inputController.OnShootEvent -= OnShoot;
		_inputController.OnUseSkillEvent -= OnUseSkill;
	}
}
