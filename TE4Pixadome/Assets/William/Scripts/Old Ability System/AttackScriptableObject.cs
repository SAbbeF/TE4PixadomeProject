using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class AttackScriptableObject : ScriptableObject
{
    [Header("General Settings")]
    public Image abilityImage;
    public float damageScale;
    public float speed;
    public float manaCost; //doesnt have to be mana could be other resources aswell :)
    public float lifeTime;
    public float cooldown;
    public bool destroyOnCollision;
    public bool dealDamage;
    public bool healDamage;
    //protected float cooldownCounter;
    //protected bool isCooldown = false;

    [Header("Explosion After Set Mount Of Time")]
    public bool isExplosion;
    public bool explodeOnCollision;
    public float durationUntilExplosion;
    public float xRadius;
    public float yRadius;
    public float zRadius;


    [Header("Skillshot")]
    public bool isSkillshot;


}
