using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerScript : MonoBehaviour
{

    public GameObject intro1;
    public GameObject intro2;
    public GameObject intro3;
    public GameObject login;
    public GameObject register;
    public GameObject detectPanel;
    public GameObject arPanel;

    //find using FindObjectOfType<ARSession>();
    private Camera arCamera;
    //public GameObject xrOrigin;

    PlaceManager placeManager;
    GameObject newPlacedObject;
    private PlaceIndicator placeIndicator;


    public UserManagerScript userManager;
    public TextMeshProUGUI logbox;


    public ARCameraController cameraManagerScript;



    void Start()
    {
        cameraManagerScript = FindObjectOfType<ARCameraController>();

        placeIndicator = FindObjectOfType<PlaceIndicator>();
        placeManager = FindObjectOfType<PlaceManager>();



        //arCamera = FindAnyObjectByType<Camera>();

        // change to reference from unity ui?
        //userManager = FindObjectOfType<UserManagerScript>();



        // managed by usermanager for now
        /*        arCamera.gameObject.SetActive(false);

                intro1.SetActive(true);
                intro2.SetActive(false);
                intro3.SetActive(false);
                login.SetActive(false);
                register.SetActive(false);
                detectPanel.SetActive(false);
                arPanel.SetActive(false);*/

        //arCamera.enabled = false;
        //arCamera.gameObject.SetActive(false);
        //xrOrigin.SetActive(false);
        cameraManagerScript.DisableARCamera();

        disableAll();
        logbox.text += "\nTrigger SCript init";
        //intro1Active();
        userManager.StartUserManagement();

    }

    public void intro1Active()
    {
        //arCamera.gameObject.SetActive(false);
        cameraManagerScript.DisableARCamera();
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
        //arCamera.gameObject.SetActive(false);

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
        //arCamera.gameObject.SetActive(false);

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
        //arCamera.gameObject.SetActive(false);

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
        //arCamera.gameObject.SetActive(false);

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
        //arCamera.gameObject.SetActive(true);
        //arCamera.enabled = true;
        //xrOrigin.SetActive(true);
        cameraManagerScript.EnableARCamera();

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

    public void disableAll()
    {
        newPlacedObject = placeManager.GetNewPlacedObject();
        if (newPlacedObject != null)
        {
            Destroy(newPlacedObject);
        }

        //arCamera.gameObject.SetActive(false);
        //arCamera.enabled = false;
        //xrOrigin.SetActive(false);
        cameraManagerScript.DisableARCamera();

        placeIndicator.gameObject.SetActive(false);

        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        login.SetActive(false);
        register.SetActive(false);
        detectPanel.SetActive(false);
        arPanel.SetActive(false);
    }

}
