using System.Collections;
using UnityEngine;

public class WeaponUse : MonoBehaviour
{
    WeaponChoice chosenWeaponScript;
    WeaponResources weaponResources;
    private void Awake() 
    {
        chosenWeaponScript = GetComponent<WeaponChoice>();
        weaponResources = GetComponent<WeaponResources>();    
    }
    void Update()
    {
        if((Input.GetMouseButtonDown(0)) && !Input.GetMouseButton(1))
        {
            if(weaponResources.WeaponsResources[chosenWeaponScript.ChosenType] > 0)
            {
                Events.OnUsingWeapon?.Invoke(chosenWeaponScript.ChosenType);
                chosenWeaponScript.GetComponentInChildren<IWeaponUse>().WeaponUse();
                Events.OnWeaponResourcesEnded?.Invoke(chosenWeaponScript.ChosenType);
            }
        }    
    }
}
