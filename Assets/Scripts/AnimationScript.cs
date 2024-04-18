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

    private DataStoreScript dataStore;


    void Start()
    {
        dataStore = FindObjectOfType<DataStoreScript>();
    }

/*    public void Idle()
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
    }*/


    public void Animate()
    {
        string exercise = dataStore.currentExercise;
        Debug.Log("Exercise: " + exercise);
        if (!dataStore.isDoingExercise)
        { 
            animator.SetTrigger(exercise); 
            dataStore.isDoingExercise = true;
        }
        else
        {
            animator.SetTrigger("idleTrigger");
            dataStore.isDoingExercise = false;
        }
    }    


}
