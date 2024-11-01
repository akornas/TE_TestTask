public class BulletPool : AbstractMonoBehaviourPool<Bullet>
{
	protected override Bullet CreatePooledItem()
	{
		var createdBullet = Instantiate(_prefab);
		createdBullet.Initialize(this);
		createdBullet.transform.SetParent(this.transform);

		return createdBullet;
	}
}
