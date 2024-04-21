using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lancerGrenade : MonoBehaviour
{
    [Header("Reference")]
    public Transform cam;
    public Transform pointAttaque;
    public GameObject grenade;

    [Header("Settings")]
    public float lancerCooldown;

    [Header("Throwing")]
    public KeyCode toucheLancer = KeyCode.Alpha3;
    public float forceLancer;
    public float forceLancerHaut;

    bool lancerDispo;

    // Start is called before the first frame update
    void Start()
    {
        lancerDispo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toucheLancer) && lancerDispo)
        {
            Lancer();
        }
    }

    void Lancer()
    {
        lancerDispo = false;

        GameObject grenadeGenere = Instantiate(grenade, pointAttaque.position, cam.rotation);
        grenadeGenere.SetActive(true);

        Rigidbody grenadeGenereRb = grenadeGenere.GetComponent<Rigidbody>();

        Vector3 forceAjouter = cam.transform.forward * forceLancer + transform.up * forceLancerHaut;

        grenadeGenereRb.AddForce(forceAjouter, ForceMode.Impulse);

        Invoke("RemettreLancer", lancerCooldown);
    }

    void RemettreLancer()
    {
        lancerDispo = true;
    }
}
