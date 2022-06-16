using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]GameObject bulletPrefab;
    Transform shootingPoint;
    Vector3 playerOriginalPosition;
    ParticleSystem canonBallShotEffect;
    void Awake() 
    {
        shootingPoint = GetComponentInChildren<Transform>();
        canonBallShotEffect = GetComponentInChildren<ParticleSystem>();    
    }
    void Start()
    {
        StartCoroutine(BulletSpawn());
    }
    IEnumerator BulletSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(8f,15f));
            canonBallShotEffect.Play();
            playerOriginalPosition = GameManager.Instance.Fps.transform.position;
            Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        }
    }
}
