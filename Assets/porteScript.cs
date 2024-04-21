using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porteScript : MonoBehaviour
{
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public bool ouvrirPorte = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
          
            ouvrirPorte = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
   
        ouvrirPorte = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ouvrirPorte == true)
            {
                AnimeObject.GetComponent<Animator>().Play("porteOUVrire");
                ThisTrigger.SetActive(false);
                ouvrirPorte = false;
            }
        }
    }
}
