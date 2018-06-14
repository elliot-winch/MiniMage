using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{

    public readonly string name;
    public readonly string buttonName;

    public readonly float coolDown;
    protected float coolDownTimer;

    protected /*Player or Enemy*/ Character character; //who is able to use this ability;

    public Ability(string name, float coolDown, Character character)
    {
        this.name = name;
        this.coolDown = coolDown;
        this.character = character;
    }

    public virtual void Update(float deltaTime)
    {
        coolDownTimer -= deltaTime;
    }

    public virtual bool CanLaunch(params float[] additionalInfo)
    {
        return coolDownTimer <= 0;
    }

    public virtual void Launch()
    {
        coolDownTimer = coolDown;
    }
}