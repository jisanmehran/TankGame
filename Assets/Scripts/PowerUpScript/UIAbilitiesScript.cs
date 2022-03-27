using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilitiesScript : MonoBehaviour
{
    [Header("Ability 1 Player 1")]
    public Image abilityImage1P1;
    public float cooldown1P1 = 5;
    bool iscooldown1P1 = false;
    public bool triggercooldown1P1 = false;

/////////////////////////////////////////////////////

    [Header("Ability 2 Player 1")]
    public Image abilityImage2P1;
    public float cooldown2P1 = 5;
    bool iscooldown2P1 = false;
    public bool triggercooldown2P1 = false;

//////////////////////////////////////////////////////

    [Header("Ability 1 Player 2")]
    public Image abilityImage1P2;
    public float cooldown1P2 = 5;
    bool iscooldown1P2 = false;
    public bool triggercooldown1P2 = false;

/////////////////////////////////////////////////////

    [Header("Ability 2 Player 2")]
    public Image abilityImage2P2;
    public float cooldown2P2 = 5;
    bool iscooldown2P2 = false;
    public bool triggercooldown2P2 = false;

/////////////////////////////////////////////////////


    // Start is called before the first frame update
    void Start()
    {
        abilityImage1P1.fillAmount = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        Ability1P1();
        Ability2P1();

        Ability1P2();
        Ability2P2();
    }

    void Ability1P1()
    {
        if (triggercooldown1P1 == true && iscooldown1P1 == false)
        {
            iscooldown1P1 = true;
            abilityImage1P1.fillAmount = 0;
        }

        if (iscooldown1P1)
        {
            abilityImage1P1.fillAmount += 1 / cooldown1P1 * Time.deltaTime;

            if (abilityImage1P1.fillAmount >= 1)
            {
                abilityImage1P1.fillAmount = 1;
                iscooldown1P1 = false;
                triggercooldown1P1 = false;
            }
        }
    }

    void Ability2P1()
    {
        if (triggercooldown2P1 == true && iscooldown2P1 == false)
        {
            iscooldown2P1 = true;
            abilityImage2P1.fillAmount = 0;
        }

        if (iscooldown2P1)
        {
            abilityImage2P1.fillAmount += 1 / cooldown2P1 * Time.deltaTime;

            if (abilityImage2P1.fillAmount >= 1)
            {
                abilityImage2P1.fillAmount = 1;
                iscooldown2P1 = false;
                triggercooldown2P1 = false;
            }
        }
    }

    void Ability1P2()
    {
        if (triggercooldown1P2 == true && iscooldown1P2 == false)
        {
            iscooldown1P2 = true;
            abilityImage1P2.fillAmount = 0;
        }

        if (iscooldown1P2)
        {
            abilityImage1P2.fillAmount += 1 / cooldown1P2 * Time.deltaTime;

            if (abilityImage1P2.fillAmount >= 1)
            {
                abilityImage1P2.fillAmount = 1;
                iscooldown1P2 = false;
                triggercooldown1P2 = false;
            }
        }
    }

    void Ability2P2()
    {
        if (triggercooldown2P2 == true && iscooldown2P2 == false)
        {
            iscooldown2P2 = true;
            abilityImage2P2.fillAmount = 0;
        }

        if (iscooldown2P2)
        {
            abilityImage2P2.fillAmount += 1 / cooldown2P2 * Time.deltaTime;

            if (abilityImage2P2.fillAmount >= 1)
            {
                abilityImage2P2.fillAmount = 1;
                iscooldown2P2 = false;
                triggercooldown2P2 = false;
            }
        }
    }
}
