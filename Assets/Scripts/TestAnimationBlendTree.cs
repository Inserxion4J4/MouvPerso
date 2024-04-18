using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationBlendTree : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float velociteMaximaleMarche = 0.5f;
    public float velociteMaximalCourse = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool boutonHaut = Input.GetKey(KeyCode.W);
        bool boutonGauche = Input.GetKey(KeyCode.A);
        bool boutonDroite = Input.GetKey(KeyCode.D);
        bool boutonCourse = Input.GetKey(KeyCode.LeftShift);

        float velociteMaxActuelle = boutonCourse ? velociteMaximalCourse : velociteMaximaleMarche;

        if (boutonHaut && velocityZ < velociteMaxActuelle)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        if (boutonGauche && velocityX > velociteMaxActuelle)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if (boutonDroite && velocityX < velociteMaxActuelle)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        if (!boutonHaut && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        if (!boutonHaut && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }
        if (!boutonGauche && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }
        if (!boutonDroite && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
        if (!boutonGauche && !boutonDroite && velocityX !=0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }
        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);
    }

    
}
