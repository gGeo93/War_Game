using UnityEngine;
public class GoblinHealthBar : EnduranceFunctionality, IDamageable
{
    public bool IsAlive => hpBar.value > 0;
    public void DamageCaused(int damage)
    {
        DamageTaken(damage);
    }

    protected override void ToBeDestroyed()
    {
        ToBeDestroyedSoundEffect();
        TowersRemainingDefendersMessages();
    }
    protected override void ToBeDestroyedSoundEffect()
    {
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.GoblinDyingSound);    
    }
    protected override void TowersRemainingDefendersMessages()
    {
        Debug.Log("Last Defender is dead!");
    }
}
