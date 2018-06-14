using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileAbility : Ability
{
    GameObject fireballObj;
    float damage;
    float launchSpeed;
    float range; 

    public ProjectileAbility(string name, float coolDown, Character character, GameObject fireballObj, float damage, float launchSpeed, float range) : base(name, coolDown, character)
    {
        this.fireballObj = fireballObj;
        this.damage = damage;
        this.launchSpeed = launchSpeed;
        this.range = range;
    }

    public bool InRange(float distance)
    {
        return distance <= range;
    }

    public override void Launch()
    {
        base.Launch();

        GameObject go = MonoBehaviour.Instantiate(fireballObj, character.transform.position + new Vector3(0f, 1.5f, 0f), character.transform.rotation);

        foreach (Collider c in go.GetComponentsInChildren<Collider>())
        {
            foreach (Collider d in character.GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(c, d);
            }
        }

        go.GetComponent<Rigidbody>().velocity = go.transform.forward * launchSpeed;

        go.GetComponent<ProjectileCollision>().Init(damage, launchSpeed, range);
    }
}