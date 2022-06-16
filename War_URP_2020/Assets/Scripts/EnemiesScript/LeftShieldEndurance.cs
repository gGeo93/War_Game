public class LeftShieldEndurance : EnduranceFunctionality, IDamageable
{
    public void DamageCaused(int damage)
    {
        DamageTaken(damage);
    }

    protected override void ToBeDestroyed()
    {
        ToBeDestroyedSoundEffect();
        TowersRemainingDefendersMessages();
        RemoveDestroyedPartFromTheList();
        TowersRemainingDefendersMessages();
        DestroyThePart();    
    }
    protected override void ToBeDestroyedSoundEffect()
    {
        GameManager.Instance.AudioManager.SoundToPlay(GameManager.Instance.AudioManager.towerShieldDestructionSound);
    }
}
