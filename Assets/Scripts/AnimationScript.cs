using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{


    // not used anymore
    /*    public GameObject panelTwo;
        public GameObject panelOne;*/


    // hidden because the value is being set in PlaceManager.cs
    [HideInInspector]
    public Animator animator;


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
