using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator animator;
    public GameObject panelTwo;
    public GameObject panelOne;



    void Start()
    {
    
    }

    public void Idle()
    {
        animator.SetTrigger("idleTrigger");
    }
    public void SitUps()
    {
        animator.SetTrigger("sitUpsTrigger");
    }
    public void AirSquats()
    {
        animator.SetTrigger("airSquatsTrigger");
    }
    public void PikeWalk()
    {
        animator.SetTrigger("pikeWalkTrigger");
    }



}
