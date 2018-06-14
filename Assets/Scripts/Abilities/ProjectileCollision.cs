using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    float damage;

	public void Init(float damage, float launchSpeed, float range)
    {
        this.damage = damage;

        Destroy(gameObject, range / launchSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.collider.gameObject;

        if(go.GetComponentInParent<Damageable>() != null)
        {
            go.GetComponentInParent<Damageable>().Hit(damage);

        }

        Destroy(gameObject);
    }
}