using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class EnduranceFunctionality : MonoBehaviour
{
   protected TowerRemainingParts towerRemainingParts;
   private TextMeshProUGUI hpPoints;
   protected Slider hpBar;
   
   private void Awake() 
   {
       towerRemainingParts = GetComponentInParent<TowerRemainingParts>();
       hpPoints = GetComponentInChildren<TextMeshProUGUI>();
       hpBar = GetComponentInChildren<Slider>();
   }
   
   protected void DamageTaken(int damage)
   {
       if(this.gameObject.CompareTag(CanBeDestroyed()))
       {
            if(damage < hpBar.value)
            {
                hpBar.value -= damage;
                hpPoints.text = (int.Parse(hpPoints.text) - damage).ToString();
            }
            else
            {
                hpBar.value = 0;
                hpPoints.text = "0";
                ToBeDestroyed();
            }
       }
   }
   private string CanBeDestroyed()
   {
        if(towerRemainingParts.towerPieces.Any(piece => piece.CompareTag("Destroyable")))
        {
            return "Destroyable";
        }
        else if(towerRemainingParts.towerPieces.Count > 0)       
        {
            return "Destroyable Cannon";
        }
        else
            return "Goblin";
   }
   protected abstract void ToBeDestroyed();
   protected abstract void ToBeDestroyedSoundEffect();
   protected virtual void TowersRemainingDefendersMessages() => Debug.Log("tower pieces: " + towerRemainingParts.towerPieces.Count);
   protected void RemoveDestroyedPartFromTheList() => towerRemainingParts.towerPieces.Remove(this.gameObject);
   protected void DestroyThePart() => Destroy(this.gameObject);
}
