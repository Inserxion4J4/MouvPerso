using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balleEnnemi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision infoCollision)
    {
        Destroy(gameObject);

        if (infoCollision.gameObject.tag == "Player")
        {
            gestionUI.nbrPvActuel -= 20;
        }
    }
}

