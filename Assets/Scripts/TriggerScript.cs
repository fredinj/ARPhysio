using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    public GameObject intro1;
    public GameObject intro2;
    public GameObject intro3;
    public GameObject login;
    public GameObject register;
    public GameObject detectPanel;
    public GameObject arPanel;
    public Camera arCamera;

    PlaceManager placeManager;
    GameObject newPlacedObject;
    private PlaceIndicator placeIndicator;

    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
        placeManager = FindObjectOfType<PlaceManager>();

        arCamera.gameObject.SetActive(false);

        intro1.SetActive(true);
        intro2.SetActive(false);
        intro3.SetActive(false);
        login.SetActive(false);
        register.SetActive(false);
        detectPanel.SetActive(false);
        arPanel.SetActive(false);
    }


    public void intro2Active()
    {
        intro1.SetActive(false);
        intro2.SetActive(true);
        intro3.SetActive(false);
        login.SetActive(false);
        register.SetActive(false);
        detectPanel.SetActive(false);
        arPanel.SetActive(false);
    }

    public void intro3Active()
    {
        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(true);
        login.SetActive(false);
        register.SetActive(false);
        detectPanel.SetActive(false);
        arPanel.SetActive(false);
    }

    public void loginActive()
    {
        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        login.SetActive(true);
        register.SetActive(false);
        detectPanel.SetActive(false);
        arPanel.SetActive(false);
    }

    public void registerActive()
    {
        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        login.SetActive(false);
        register.SetActive(true);
        detectPanel.SetActive(false);
        arPanel.SetActive(false);
    }

    public void detectActive()
    {
        arCamera.gameObject.SetActive(true);
        placeIndicator.gameObject.SetActive(true);


        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        login.SetActive(false);
        register.SetActive(false);
        detectPanel.SetActive(true);
        arPanel.SetActive(false);
    }

    public void arActive()
    {
        placeIndicator.gameObject.SetActive(false);


        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        login.SetActive(false);
        register.SetActive(false);
        detectPanel.SetActive(false);
        arPanel.SetActive(true);
    }


    public void PlaceAgain()
    {
        newPlacedObject = placeManager.GetNewPlacedObject();
        Destroy(newPlacedObject);

        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        login.SetActive(false);
        register.SetActive(false);
        detectPanel.SetActive(true);
        arPanel.SetActive(false);


        placeIndicator.gameObject.SetActive(true);
    }

}
