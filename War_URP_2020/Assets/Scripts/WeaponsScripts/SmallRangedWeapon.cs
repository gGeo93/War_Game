using System.Collections;
using UnityEngine;

public abstract class SmallRangedWeapon : MonoBehaviour
{
    protected abstract void DebugMessage();
    protected abstract void WeaponSwingSound();
    protected abstract void WeaponSwingAnimation();
    protected bool canUseWeapon = true;
}
