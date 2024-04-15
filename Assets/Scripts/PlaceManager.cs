using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceManager : MonoBehaviour
{

    private PlaceIndicator placeIndicator;
    public GameObject objectToPlace;

    public TriggerScript triggerScript;

    private GameObject newPlacedObject;

// frankenstein

    public AnimationScript animationScript;


    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
        
    }


    public void ClickToPlace()
    {
        //move back into if
/*        placeIndicator.gameObject.SetActive(false);
        panelOne.SetActive(false);
        panelTwo.SetActive(true);*/

        // frankenstein


        if (newPlacedObject == null)
            {
                //newPlacedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                newPlacedObject = Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);

                animationScript.animator = newPlacedObject.GetComponent<Animator>();

                triggerScript.arActive();

        }

            //commented out because indicator is disabled after object insantiation
/*            else
            {
                newPlacedObject.transform.position = placeIndicator.transform.position;
                newPlacedObject.transform.rotation = placeIndicator.transform.rotation;
            }*/

        //}


        // orig
        // newPlacedObject = Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);


    }


    public GameObject GetNewPlacedObject()
    {
        return newPlacedObject;
    }

}
