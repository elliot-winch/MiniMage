using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : Character {

    public GameObject fireballObj;
    public float fireballDamage;
    public float fireballCoolDown;
    public float fireballLaunchSpeed;
    public float fireballRange;


    Dictionary<string, Ability> abilityMap;

    protected override void Start()
    {
        base.Start();

        abilityMap = new Dictionary<string, Ability>();

        abilityMap["Fire1"] = new ProjectileAbility(
            name: "Fireball",
            coolDown: fireballCoolDown,
            character: GetComponent<Character>(),
            fireballObj: fireballObj,
            damage: fireballDamage,
            launchSpeed: fireballLaunchSpeed,
            range: fireballRange
        );
    }

    void Update()
    {

        foreach (string axis in abilityMap.Keys)
        {
            abilityMap[axis].Update(Time.deltaTime);

            if (abilityMap[axis].CanLaunch() && Input.GetButtonDown("Fire1"))
            {
                abilityMap[axis].Launch();
            }
        }
    }
}


