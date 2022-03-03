using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class AttackScriptableObject : ScriptableObject
{

    public float damageScale;
    public float speed;
    public float manaCost; //doesnt have to be mana could be other resources aswell :)
    public float lifeTime;
    //public float cooldown;
    //protected float cooldownCounter;
    //protected bool isCooldown = false;
    public Image abilityImage;

    public bool destroyOnCollision;
    public bool followTarget;
    public bool isSkillshot;


}
