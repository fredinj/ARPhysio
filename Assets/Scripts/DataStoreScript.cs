using System;
using UnityEngine;



public class DataStoreScript : MonoBehaviour
{
    
    public bool isUserLoggedIn;
    //public string userName;
    public string currentExercise;
    public bool isDoingExercise;


    // profile related


    public void Squats()
    {
        currentExercise = "sitUpsTrigger";
    }    
    public void PikeWalk()
    {
        currentExercise = "pikeWalkTrigger";
    }    
    public void AirSquats()
    {
        currentExercise = "airSquatsTrigger";
    }

}
