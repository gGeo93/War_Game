using UnityEngine;

public class OnTakingTheAmmo : MonoBehaviour
{
    WeaponType randomAmmoTypePickUp;
    
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Knife"))
        {
            randomAmmoTypePickUp = (WeaponType)RandomAmmo();
            Events.OnAmmoPickingUp?.Invoke(randomAmmoTypePickUp, 10);
            GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.pickUpPackage);
            Destroy(gameObject);
        }
    }
    int RandomAmmo()
    {
        int rn;
        while(true)
        {
            rn = UnityEngine.Random.Range(0,5);
            if(rn != 2)
                break;
        }
        return rn;
    }
}
