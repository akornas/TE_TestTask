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
			CreateBullet();
		}
	}

	private Bullet CreateBullet()
	{
		var bullet = _bulletPool.Get();
		bullet.transform.position = _spawnPlace.position;
		bullet.SetHitData(_playerData.GetBaseHitData());

		return bullet;
	}

	private bool CanShoot()
	{
		return Time.timeSinceLevelLoad - _lastShootTime > _playerData.ShootDelay;
	}

	private void OnUseSkill()
	{
		var skillData = _playerData.SkillData;

		if (_cooldownManager.CanUseSkill(skillData.Enum))
		{
			var bullet = CreateBullet();
			AddBehaviourToBullet(skillData, bullet);
		}
	}

	private void AddBehaviourToBullet(SkillData skillData, Bullet bullet)
	{
		var behaviour = _bulletBehaviourFactory.Create(skillData.Enum);
		bullet.AddBehaviour(behaviour);
		_cooldownManager.AddSkillCooldown(skillData);
	}

	private void OnDisable()
	{
		_inputController.OnShootEvent -= OnShoot;
		_inputController.OnUseSkillEvent -= OnUseSkill;
	}
}
