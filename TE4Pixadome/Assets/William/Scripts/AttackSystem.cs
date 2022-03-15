using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Mirage;

public class AttackSystem : NetworkBehaviour
{
    public GameObject autoAttack;
    
    public GameObject firstAbility;
    public GameObject secondAbility;
    public GameObject thirdAbility;
    public Image firstAbilityImage;
    public Image secondAbilityImage;
    public Image thirdAbilityImage;
    Ability firstAbilityStats;
    Ability secondAbilityStats;
    Ability thirdAbilityStats;
    Ability autoAttackStats;


    public Transform castPoint;

    MyInputManager myInputManager;
    GetTarget getTarget;
    NavMeshAgent agent;
    Stats stats;
    ManaScript manaScript;

    float autoAttackCooldown;
    float autoAttackCounter;
    float autoAttackScaledValue;
    bool isAutoAttackOnCooldown;

    float firstAbilityCooldown;
    float firstAbilityCounter;
    float firstAbilityScaledValue;
    bool isFirstAbilityOnCooldown;

    float secondAbilityCooldown;
    float secondAbilityCounter;
    float secondAbilityScaledValue;
    bool isSecondAbilityOnCooldown;

    float thirdAbilityCooldown;
    float thirdAbilityCounter;
    float thirdAbilityScaledValue;
    bool isThirdAbilityOnCooldown;


    private void Awake()
    {
        myInputManager = new MyInputManager();
        //getTarget = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<GetTarget>();
        //getTarget.targetedObject = null;

        agent = gameObject.GetComponent<NavMeshAgent>();
        stats = gameObject.GetComponent<Stats>();
        manaScript = gameObject.GetComponent<ManaScript>();


        autoAttackStats = autoAttack.GetComponent<Ability>();
        firstAbilityStats = firstAbility.GetComponent<Ability>();
        secondAbilityStats = secondAbility.GetComponent<Ability>();
        thirdAbilityStats = thirdAbility.GetComponent<Ability>();

        autoAttackCooldown = autoAttackStats.abilityToCast.cooldown;
        firstAbilityCooldown = firstAbilityStats.abilityToCast.cooldown;
        secondAbilityCooldown = secondAbilityStats.abilityToCast.cooldown;
        thirdAbilityCooldown = thirdAbilityStats.abilityToCast.cooldown;

        autoAttackCounter = autoAttackCooldown;
        firstAbilityCounter = firstAbilityCooldown;
        secondAbilityCounter = secondAbilityCooldown;
        thirdAbilityCounter = thirdAbilityCooldown;

    }



    private void Update()
    {
        //COPY & PASTE HELL
        //MOST FIX, TRIED WITH METHOD BUT DIDNT GET IT TO WORK
        #region Cooldown management

        if (isAutoAttackOnCooldown)
        {
            autoAttackCounter += Time.fixedDeltaTime * stats.attackSpeed;

            if (autoAttackCounter >= autoAttackCooldown)
            {
                isAutoAttackOnCooldown = false;
            }
        }


        //----------------------------------------------------------------------

        if (isFirstAbilityOnCooldown)
        {
            firstAbilityCounter += Time.fixedDeltaTime * stats.cooldownReduction;

            if (firstAbilityCounter >= firstAbilityCooldown)
            {
                isFirstAbilityOnCooldown = false;
            }
        }

        firstAbilityScaledValue = firstAbilityCounter / firstAbilityCooldown;
        firstAbilityImage.fillAmount = firstAbilityScaledValue;

        //----------------------------------------------------------------------

        if (isSecondAbilityOnCooldown)
        {
            secondAbilityCounter += Time.fixedDeltaTime * stats.cooldownReduction;

            if (secondAbilityCounter >= secondAbilityCooldown)
            {
                isSecondAbilityOnCooldown = false;
            }
        }

        secondAbilityScaledValue = secondAbilityCounter / secondAbilityCooldown;
        secondAbilityImage.fillAmount = secondAbilityScaledValue;

        //----------------------------------------------------------------------

        if (isThirdAbilityOnCooldown)
        {
            thirdAbilityCounter += Time.fixedDeltaTime * stats.cooldownReduction;

            if (thirdAbilityCounter >= thirdAbilityCooldown)
            {
                isThirdAbilityOnCooldown = false;
            }
        }

        thirdAbilityScaledValue = thirdAbilityCounter / thirdAbilityCooldown;
        thirdAbilityImage.fillAmount = thirdAbilityScaledValue;
        #endregion

        if (!IsLocalPlayer) return;

        if (!isAutoAttackOnCooldown && myInputManager.PlayerController.AutoAttack.triggered)
        {
            InstantiateAutoAttack();
        }

        if (!isFirstAbilityOnCooldown && myInputManager.PlayerController.FirstAbility.triggered)
        {
            InstantiateFirstAbility();
        }

        if (!isSecondAbilityOnCooldown && myInputManager.PlayerController.SecondAbility.triggered)
        {

            InstantiateSecondAbility();
        }

        if (!isThirdAbilityOnCooldown && myInputManager.PlayerController.ThirdAbility.triggered)
        {
            InstantiateThirdAbility();
        }

        stats.currentMana = manaScript.ManaRegeneration(stats.currentMana, stats.maxMana, stats.manaRegenerationTickRate);

        manaScript.SetManaValue(stats.currentMana);
    }

    void InstantiateAutoAttack()
    {

        
        Instantiate(autoAttack, castPoint.transform.position, castPoint.rotation);
        autoAttackCounter = 0;
        isAutoAttackOnCooldown = true;
    }

    void InstantiateFirstAbility()
    {
        Instantiate(firstAbility, castPoint.transform.position, castPoint.rotation);
        firstAbilityCounter = 0;
        isFirstAbilityOnCooldown = true;
    }

    void InstantiateSecondAbility()
    {
        if (stats.currentMana > secondAbilityStats.abilityToCast.manaCost)
        {

            Instantiate(secondAbility, castPoint.transform.position, castPoint.rotation);
            secondAbilityCounter = 0;
            isSecondAbilityOnCooldown = true;
            stats.currentMana = manaScript.ManaSubtraction(stats.currentMana, secondAbilityStats.abilityToCast.manaCost);

        }
    }
    void InstantiateThirdAbility()
    {
        Instantiate(thirdAbility, castPoint.transform.position, castPoint.rotation);
        thirdAbilityCounter = 0;
        isThirdAbilityOnCooldown = true;
    }

    bool CooldownHandler(float cooldownCounter, float cooldownDuration, float scaledValue, Image icon)
    {

        cooldownCounter += Time.fixedDeltaTime;
        scaledValue = cooldownCounter / cooldownDuration;
        icon.fillAmount = scaledValue;

        if (cooldownCounter >= cooldownDuration)
        {
            return false;
        }
        else
        {
            return true;
        }


    }

    private void OnEnable()
    {
        myInputManager.PlayerController.Enable();
        //myInputManager.PlayerMouse.Enable();

    }

    private void OnDisable()
    {
        myInputManager.PlayerController.Disable();
        //myInputManager.PlayerMouse.Disable();

    }
}
