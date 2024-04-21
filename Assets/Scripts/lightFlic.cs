using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlic : MonoBehaviour
{
    // Start is called before the first frame update
    public bool lightClignotant = false;
    public float delai;

    // Update is called once per frame
    void Update()
    {
        if (lightClignotant == false) 
        {
            StartCoroutine(lightClignotante());
        }
    }

    IEnumerator lightClignotante()
    {
        lightClignotant=true;
        this.gameObject.GetComponent<Light>().enabled = false;
        delai = Random.Range(0.01f ,0.2f);
        yield return new WaitForSeconds(delai);
        this.gameObject.GetComponent<Light>().enabled = true;
        delai = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(delai);
        lightClignotant = false;
    }
    
}
