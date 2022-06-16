using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject hurtEffect;
    [SerializeField] Animator playerAnimator;
    
    void Start() 
    {
        Events.OnPlayerDying += PlayerDiesSoundEffect;  
        Events.OnPlayerDying += PlayerDiesAnimation;
    }
    void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Cannon Ball"))
        { 
            hurtEffect.SetActive(true);
            StartCoroutine(HurtEffectFade(other.gameObject));
        }
    }
    IEnumerator HurtEffectFade(GameObject go)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(go);
        hurtEffect.SetActive(false);
    }
    public void PlayerGetsHurt() => GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.playerGetsHurt);
    void PlayerDiesSoundEffect() => GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.playerDiesSound);
    void PlayerDiesAnimation() => playerAnimator.SetTrigger("isDying");
}

