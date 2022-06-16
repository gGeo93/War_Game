using System.Collections;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour,IWeaponUse
{
    Animator animator;
    Rigidbody rb;
    SphereCollider sphereCollider;
    public bool isHoldingGrenade;
    
    void Awake() 
    {
        animator = GetComponentInParent<Animator>();
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        
    }
    void Start() 
    {
        isHoldingGrenade = true;
        rb.isKinematic = true; 
        rb.useGravity = false;   
    }
    public void WeaponUse()
    {
        if(isHoldingGrenade)
        {
            isHoldingGrenade = false;
            DebugMessage();
            GrenadeAnimation();
            StartCoroutine(GrenadeToBeThrown());
        }
    }
    void DebugMessage() => Debug.Log("Grenade throw!");
    void GrenadeAnimation() => animator.SetTrigger("isUsingGrenade");
    IEnumerator GrenadeToBeThrown()
    {
        yield return new WaitForSeconds(1f);

        transform.parent = null;

        Vector3 grenadeDir = Camera.main.transform.forward;
        rb.isKinematic = false;
        rb.AddForce(1000f * grenadeDir);
        rb.useGravity = true;
    }
}
