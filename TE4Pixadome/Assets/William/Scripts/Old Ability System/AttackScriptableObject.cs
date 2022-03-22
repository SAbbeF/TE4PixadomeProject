using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class AttackScriptableObject : ScriptableObject
{
    [Header("General Settings")]
    public Image abilityIcon;
    public float damageScale;
    public float speed;
    public float manaCost; //doesnt have to be mana could be other resources aswell :)
    public float lifeTime;
    public float cooldown;
    public bool destroyOnCollision;
    public bool dealDamage;
    //protected float cooldownCounter;
    //protected bool isCooldown = false;

    [Header("Explosion")]
    public bool explodeOnCollision;
    public bool explodeAfterSetAmountOfTime;
    public float durationUntilExplosion;
    public float xRadius;
    public float yRadius;
    public float zRadius;


    [Header("Skillshot")]
    public bool isSkillshot;


    [Header("Heal")]
    public bool healTarget;
    public bool selfHeal;

    [Header("Wall")]
    public bool destroyProjectiles;


}
