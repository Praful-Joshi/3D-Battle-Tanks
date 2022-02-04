using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static event Action attackedEnemy;

    public LayerMask tankMask;
    public AudioSource explosionAudioSource;

    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        BulletPool.instance.returnBullet(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius, tankMask);
        foreach(Collider c in colliders)
        {
            Rigidbody targetRigidbody = c.GetComponent<Rigidbody>();
            if(!targetRigidbody)
            {
                continue;
            }
            Debug.Log(targetRigidbody);
            attackedEnemy?.Invoke();
            targetRigidbody.AddExplosionForce(explosionForce, this.transform.position, explosionRadius);
            EnemyHealth targetHealth = targetRigidbody.GetComponent<EnemyHealth>();

            if(!targetHealth)
            {
                continue;
            }

            float damage = calculateDamage(targetRigidbody.position);
            Debug.Log("Damage given - " + damage);
            targetHealth.takeDamage(damage);
        }
        explosionAudioSource.Play();
        BulletPool.instance.returnBullet(this.gameObject);
    }

    private float calculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - this.transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
}
