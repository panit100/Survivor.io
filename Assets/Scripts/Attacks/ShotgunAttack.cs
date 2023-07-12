using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAttack : BaseAttack
{
    [SerializeField] private float bulletDamage = 8f;
    [SerializeField] private int bulletTotal = 1;
    [SerializeField] private float shootCooldown = 1f;
    [SerializeField] private float bulletGapAngle = 10f;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform bulletShootPoint;
    [SerializeField] private GameObject shotgunSprite, shotgunLight;

    private float bulletAngleDegree;
    private Vector3 bulletAngleVector;

    private void Start()
    {
        SetupBulletTotal();
        ShootBullet();
        ShotgunSetup();
    }
    private void SetupBulletTotal()
    {
        if(bulletTotal > 1 && bulletTotal % 2 == 0)
        {
            bulletTotal = bulletTotal - 1;
        }
    }
    private void ShotgunSetup()
    {
        shotgunSprite.SetActive(false);
        shotgunLight.SetActive(false);
    }

    private void ShootBullet()
    {
        StopAllCoroutines();
        StartCoroutine(ShootBulletSequence());
    }
    private IEnumerator ShootBulletSequence()
    {
        shotgunSprite.SetActive(false);
        shotgunSprite.SetActive(true);
        shotgunLight.SetActive(true);
        LoopCreateBullet();

        yield return new WaitForSeconds(0.1f);
        shotgunLight.SetActive(false);

        yield return new WaitForSeconds(shootCooldown);
        ShootBullet();
    }
    private void LoopCreateBullet()
    {
        bulletAngleDegree = bulletShootPoint.eulerAngles.z;
        for(int i = 0; i < bulletTotal; i++)
        {
            Transform bullet = Instantiate(bulletObject, bulletShootPoint.position, bulletShootPoint.rotation).transform;
            bullet.GetComponent<ShotgunBullet>().SetupBulletProperty(bulletDamage);
            bullet.eulerAngles = new Vector3(0, 0, CheckAngle(i + 1));
        }
    }
    private float angleTemp;
    private float CheckAngle(int count)
    {
        angleTemp = 0;
        if(count == 1)
        {
            angleTemp = bulletShootPoint.eulerAngles.z;
        }
        else if(count % 2 == 0 && count > 1)
        {
            bulletAngleDegree += bulletGapAngle;
            angleTemp = bulletAngleDegree;
        }
        else if(count % 2 == 1 && count > 1)
        {
            angleTemp = -bulletAngleDegree;
        }

        return angleTemp;
    }

    public override void UpgradeWeaponLevel()
    {
        bulletTotal += 2;
        shootCooldown *= 0.9f;
        weaponLevel++;
    }
}