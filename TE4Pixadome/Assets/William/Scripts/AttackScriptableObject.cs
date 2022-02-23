using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class AttackScriptableObject : ScriptableObject
{

    public float damage;
    public float speed;
    public float manaCost; //doesnt have to be mana could be other resources aswell :)
    public float lifeTime;
    public float abilitySize;
    public bool destroyOnCollision;
    public bool followTarget;


}
