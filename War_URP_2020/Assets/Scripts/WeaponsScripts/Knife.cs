using UnityEngine;

public class Knife : SmallRangedWeapon,IWeaponUse
{
    Animator animator;
    BoxCollider knifeSharp;
    void Awake() 
    {
        animator = GetComponentInParent<Animator>();
        knifeSharp = GetComponent<BoxCollider>();
    }
    public void WeaponUse()
    {
        DebugMessage();
        WeaponSwingSound();
        WeaponSwingAnimation();
    }
    protected override void DebugMessage() => Debug.Log("Knife use!");
    protected override void WeaponSwingSound() => GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.knifeSwingSound);
    protected override void WeaponSwingAnimation() => animator.SetTrigger("isUsingKnife");
}
