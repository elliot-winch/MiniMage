using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : Damageable {

    public GameObject fireSystem;

    private const float burnTime = 3f;

    public override void Hit(float amount)
    {
        StartCoroutine(Burn(amount));        
    }

    private IEnumerator Burn(float amount)
    {
        float timer = burnTime;

        fireSystem.SetActive(true);

        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            base.Hit(amount * Time.deltaTime / burnTime);

            yield return null;
        }

        fireSystem.SetActive(false);

    }
}
