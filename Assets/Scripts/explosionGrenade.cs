using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionGrenade : MonoBehaviour
{
    //public float delai;

    //float decompte;
    //bool aExplose = false;

    public float rayonExplosion = 5f;
    public float forceExplosion;

    // Start is called before the first frame update
    void Start()
    {
        //decompte = delai;
    }

    // Update is called once per frame
    void Update()
    {
        //decompte -= Time.deltaTime;

        //if (decompte <= 0f && !aExplose)
        //{
        //    Explosion();
        //    aExplose = true;
        //}
    }

    private void OnCollisionEnter(Collision infCollision)
    {
        Explosion();
    }

    void Explosion()
    {
        // Instantiate(effetExplosion, transform.position, transform.rotation);
        Destroy(gameObject);

        Collider[] collisions = Physics.OverlapSphere(transform.position, rayonExplosion);
        foreach (Collider objetsProches in collisions)
        {
            Rigidbody rb = objetsProches.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(forceExplosion, transform.position, rayonExplosion);

                if (objetsProches.gameObject.CompareTag("ennemi"))
                {
                    Destroy(objetsProches.gameObject);
                }
            }
        }
    }
}
