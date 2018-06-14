using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character {

    public Damageable target;
    public float updatePathTime = 2f;

    public float minimumRange = 2f;

    private NavMeshAgent agent;
    public GameObject fireballObj;
    public float fireballDamage;
    public float fireballCoolDown;
    public float fireballLaunchSpeed;
    public float fireballRange;

    protected List<Ability> abilities;

    protected override void Start()
    {
        base.Start();

        //Path finding
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(TrackTarget());

        //Abilities
        abilities = new List<Ability>();

        abilities.Add(new ProjectileAbility(
            name: "Fireball",
            coolDown: fireballCoolDown,
            character: GetComponent<Character>(),
            fireballObj: fireballObj,
            damage: fireballDamage,
            launchSpeed: fireballLaunchSpeed,
            range: fireballRange
        ));

    }

    IEnumerator TrackTarget()
    {
        while (true)
        {

            if(Vector3.Distance(transform.position, target.transform.position) > minimumRange)
            {
                agent.SetDestination(target.transform.position);
            } 

            yield return new WaitForSeconds(updatePathTime);
        }
    }

    void Update()
    {
        //How should the AI decide which abilitiy to use?
        //Right now, we just choose the first ability that is valid and in range

        transform.LookAt(target.transform.position);

        foreach (Ability a in abilities)
        {
            a.Update(Time.deltaTime);

            if (a.CanLaunch())
            {

                if (a is ProjectileAbility)
                {
                    if (((ProjectileAbility)a).InRange(Vector3.Distance(transform.position, target.transform.position)) == false)
                    {
                        continue;
                    }
                }

                a.Launch();
                return;
            }
        }
    }

}
