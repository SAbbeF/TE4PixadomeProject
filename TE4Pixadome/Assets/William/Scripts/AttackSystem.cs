using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{

    #region Variables

    public GameObject autoAttack;
    
    public GameObject firstAbility;
    public GameObject secondAbility;
    public GameObject thirdAbility;
    Image firstAbilityTempImage;
    Image secondAbilityTempImage;
    Image thirdAbilityTempImage;
    Image firstAbilityIcon;
    Image secondAbilityIcon;
    Image thirdAbilityIcon;
    Ability firstAbilityStats;
    Ability secondAbilityStats;
    Ability thirdAbilityStats;
    Ability autoAttackStats;

    //[SerializeField] public Canvas playerHud;
    public Transform firstSlot;
    public Transform secondSlot;
    public Transform thirdSlot;

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

    #endregion

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


        firstAbilityTempImage = firstAbilityStats.abilityToCast.abilityIcon;
        secondAbilityTempImage = secondAbilityStats.abilityToCast.abilityIcon;
        thirdAbilityTempImage = thirdAbilityStats.abilityToCast.abilityIcon;

        InstantiateAbilityIcons(firstAbilityTempImage, secondAbilityTempImage, thirdAbilityTempImage);

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
        firstAbilityIcon.fillAmount = firstAbilityScaledValue;

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
        secondAbilityIcon.fillAmount = secondAbilityScaledValue;

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
        thirdAbilityIcon.fillAmount = thirdAbilityScaledValue;
        #endregion

        if (!isAutoAttackOnCooldown && myInputManager.PlayerController.AutoAttack.triggered)
        {
            InstantiateAutoAttack();
        }

        if (!isFirstAbilityOnCooldown && stats.currentMana > firstAbilityStats.abilityToCast.manaCost && myInputManager.PlayerController.FirstAbility.triggered)
        {
            InstantiateAbility(firstAbility, firstAbilityStats);
            firstAbilityCounter = 0;
            isFirstAbilityOnCooldown = true;
        }

        if (!isSecondAbilityOnCooldown && stats.currentMana > secondAbilityStats.abilityToCast.manaCost &&  myInputManager.PlayerController.SecondAbility.triggered)
        {

            InstantiateAbility(secondAbility, secondAbilityStats);
            secondAbilityCounter = 0;
            isSecondAbilityOnCooldown = true;
        }

        if (!isThirdAbilityOnCooldown && stats.currentMana > thirdAbilityStats.abilityToCast.manaCost && myInputManager.PlayerController.ThirdAbility.triggered)
        {
            InstantiateAbility(thirdAbility, thirdAbilityStats);
            thirdAbilityCounter = 0;
            isThirdAbilityOnCooldown = true;
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

    void InstantiateAbility(GameObject spellToCast, Ability spellStats)
    {



        Instantiate(spellToCast, castPoint.transform.position, castPoint.rotation);

        stats.currentMana = manaScript.ManaSubtraction(stats.currentMana, spellStats.abilityToCast.manaCost);


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

    void InstantiateAbilityIcons(Image firstIcon, Image secondIcon, Image thirdIcon)
    {

        firstAbilityIcon = Instantiate(firstIcon, firstSlot);
        secondAbilityIcon = Instantiate(secondIcon, secondSlot);
        thirdAbilityIcon = Instantiate(thirdIcon, thirdSlot);

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
