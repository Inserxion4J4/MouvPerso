using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gestionUI : MonoBehaviour
{
    // Gestion pv
    public Image barrePv;
    float nbrPvMax = 100;
    float nbrPvActuel = 100;

    // Gestion chargeur
    float chargeurActuel = 15;
    float chargeurMax = 15;
    
    public TextMeshProUGUI compteurChargeurActuel;
    public TextMeshProUGUI compteurChargeurMax;


    // Capacités

    // Capacité 1 - Dash
    public Image capaciteImageDash;
    public KeyCode toucheDash;
    float cooldownTempsDash = 5;

    bool cooldownEnCoursDash = false;
    float cooldownActuelDash;

    // Capacité 2 - Bouclier
    public Image capaciteImageBouclier;
    public KeyCode toucheBouclier;
    float cooldownTempsBouclier = 20;

    bool cooldownEnCoursBouclier = false;
    float cooldownActuelBouclier;

    // Capacité 3 - Grenade incendiaire
    public Image capaciteImageGrenade;
    public KeyCode toucheGrenade;
    float cooldownTempsGrenade = 45;

    bool cooldownEnCoursGrenade = false;
    float cooldownActuelGrenade;

    private void Start()
    {
        capaciteImageDash.fillAmount = 0;
        capaciteImageBouclier.fillAmount = 0;
        capaciteImageGrenade.fillAmount = 0;
    }

    void Update()
    {
        // Gestion capacités

        // Capacité 2 - Grenade incendiaire
        CapaciteDashInput();

        CapaciteCooldown(ref cooldownActuelDash, cooldownTempsDash, ref cooldownEnCoursDash, capaciteImageDash);

        // Capacité 2 - Grenade incendiaire
        CapaciteBouclierInput();

        CapaciteCooldown(ref cooldownActuelBouclier, cooldownTempsBouclier, ref cooldownEnCoursBouclier, capaciteImageBouclier);

        // Capacité 3 - Grenade incendiaire
        CapaciteGrenadeInput();

        CapaciteCooldown(ref cooldownActuelGrenade, cooldownTempsGrenade, ref cooldownEnCoursGrenade, capaciteImageGrenade);



        // Gestion affichage barre vie
        float pourcentagePv = nbrPvActuel / nbrPvMax;
        barrePv.fillAmount = pourcentagePv;

        // Modification barre de vie
        if (Input.GetKeyDown(KeyCode.Space) && nbrPvActuel > 0)
        {
            nbrPvActuel -= 10;
        }


        // Gestion chargeur
        compteurChargeurActuel.text = chargeurActuel.ToString();
        compteurChargeurMax.text = chargeurMax.ToString();

        if (Input.GetKeyDown(KeyCode.Mouse0) && chargeurActuel > 0)
        {
            chargeurActuel -= 1;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("Recharger", 1f);
        }
    }

    void Recharger()
    {
        chargeurActuel = chargeurMax;
    }

    void CapaciteDashInput()
    {
        if (Input.GetKeyDown(toucheDash) && !cooldownEnCoursDash)
        {
            cooldownEnCoursDash = true;
            cooldownActuelDash = cooldownTempsDash;
        }
    }

    void CapaciteBouclierInput()
    {
        if (Input.GetKeyDown(toucheBouclier) && !cooldownEnCoursBouclier)
        {
            cooldownEnCoursBouclier = true;
            cooldownActuelBouclier = cooldownTempsBouclier;
        }
    }

    void CapaciteGrenadeInput()
    {
        if (Input.GetKeyDown(toucheGrenade) && !cooldownEnCoursGrenade)
        {
            cooldownEnCoursGrenade = true;
            cooldownActuelGrenade = cooldownTempsGrenade;
        }
    }

    void CapaciteCooldown(ref float cooldownActuel, float cooldownMax, ref bool cooldownEnCours, Image capaciteImage)
    {
        if (cooldownEnCours)
        {
            cooldownActuel -= Time.deltaTime;

            if (cooldownActuel <= 0)
            {
                cooldownEnCours = false;
                cooldownActuel = 0;

                if(capaciteImage != null)
                {
                    capaciteImage.fillAmount = 0;
                }
            }
            else
            {
                if (capaciteImage != null)
                {
                    capaciteImage.fillAmount = cooldownActuel / cooldownMax;
                }
            }
        }
    }
}
