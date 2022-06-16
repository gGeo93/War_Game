using UnityEngine;
using DG.Tweening;

public class SmallGun : LongRangedWeapon,IWeaponUse
{
    ParticleSystem smallGunShotEffect;
    Transform cameraPosition;
    [SerializeField] private int smallGunDamage = 20;


    void Start() {
        cameraPosition = GetComponentInParent<Camera>().gameObject.transform;
        smallGunShotEffect = GetComponentInChildren<ParticleSystem>();    
    }
    public void WeaponUse()
    {
       SmallGunShootingProcess();
    }
    void SmallGunShootingProcess()
    {
        DebugMessage();
        ShotSound();
        ShotEffect();     
        CameraShake();
        Shooting();
    }
    protected override void DebugMessage() =>  Debug.Log("Small Gun Shoot!");
    protected override void ShotSound() => GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.smallGunShotSound);
    protected override void ShotEffect() => smallGunShotEffect.Play();
    protected override void CameraShake() => cameraPosition.transform.DOShakePosition(0.25f, 0.5f);
    protected override void Shooting()
    {
        RaycastHit hit;
        if(Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, 30f, 1<<3))
        {
            hit.collider.GetComponent<IDamageable>().DamageCaused(smallGunDamage);
        }
    }
}
