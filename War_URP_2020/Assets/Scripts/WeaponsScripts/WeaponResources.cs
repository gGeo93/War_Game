using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponResources : MonoBehaviour, IResourcesDecreasing
{
    public Dictionary<WeaponType, int> WeaponsResources = new Dictionary<WeaponType, int>(){[WeaponType.BigGun] = 10,[WeaponType.SmallGun] = 15, [WeaponType.Knife] = 100, [WeaponType.ClassicGrenade] = 6, [WeaponType.StunGrenade] = 11};
    WeaponChoice weaponChoice;
    private void Awake()
    {
        Events.OnWeaponResourcesEnded = ResourcesChecked;
        Events.OnAmmoPickingUp += ResourceIncreased;
    }    
    void Start()
    {
        weaponChoice = GetComponent<WeaponChoice>();
        Events.OnUsingWeapon += ResourceDecreased;
    }
    public void ResourceDecreased(WeaponType weaponUsed)
    {
        if(WeaponsResources[weaponUsed] > 0)
        {
            WeaponsResources[weaponUsed] -= 1;
        }
    }
    void ResourceIncreased(WeaponType weaponsAmmoKind, int ammo)
    {
        WeaponsResources[weaponsAmmoKind] += ammo;
    }
    
    void ResourcesChecked(WeaponType chosenWeapon)
    {
        if(WeaponsResources[chosenWeapon] == 0)
        {    
            weaponChoice.ChosenWeapon.SetActive(false);
            //GameManager.Instance.UIWeaponWheelHandler.WeaponDisplayDisabled();
        }
    }
}
