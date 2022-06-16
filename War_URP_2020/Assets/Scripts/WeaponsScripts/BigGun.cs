using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BigGun : LongRangedWeapon,IWeaponUse
{
    ParticleSystem bigGunShotEffect;
    Transform cameraPosition;
    [SerializeField] private int bigGunDamage = 30;

    void Start() {
        cameraPosition = GetComponentInParent<Camera>().gameObject.transform;    
        bigGunShotEffect = GetComponentInChildren<ParticleSystem>();
    }
    public void WeaponUse()
    {
        BigGunShootingProcess();
    }
    void BigGunShootingProcess()
    {
        DebugMessage();
        ShotSound();
        ShotEffect();     
        CameraShake();
        Shooting();
    }
    protected override void DebugMessage() =>  Debug.Log("Big Gun Shoot!");
    protected override void ShotSound() => GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.bigGunShotSound);
    protected override void ShotEffect() => bigGunShotEffect.Play();
    protected override void CameraShake() => cameraPosition.transform.DOShakePosition(0.5f);
    protected override void Shooting()
    {
        RaycastHit hit;
        if(Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, 50f, 1<<3))
        {
            hit.collider.GetComponent<IDamageable>().DamageCaused(bigGunDamage);
        }
    }
}
