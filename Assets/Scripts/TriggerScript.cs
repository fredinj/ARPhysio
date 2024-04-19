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
    public GameObject dashboard;
    public GameObject profile;
    public GameObject profileEdit;

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
        //cameraManagerScript.DisableARCamera();
        ManageCamera(false);

        disableAll();
        destroyDevin();
        logbox.text += "\nTrigger SCript init";
        //intro1Active();
        userManager.StartUserManagement();

    }

    public void intro1Active()
    {
        //arCamera.gameObject.SetActive(false);
        //cameraManagerScript.DisableARCamera();
        ManageCamera(false);

        disableAll();
        intro1.SetActive(true);

    }

    public void intro2Active()
    {
        //arCamera.gameObject.SetActive(false);

        disableAll();
        intro2.SetActive(true);

    }

    public void intro3Active()
    {
        //arCamera.gameObject.SetActive(false);

        disableAll();
        intro3.SetActive(true);

    }

    public void loginActive()
    {
        //arCamera.gameObject.SetActive(false);

        disableAll();
        login.SetActive(true);

    }

    public void registerActive()
    {
        //arCamera.gameObject.SetActive(false);

        disableAll();
        register.SetActive(true);

    }

    public void detectActive()
    {
        //arCamera.gameObject.SetActive(true);
        //arCamera.enabled = true;
        //xrOrigin.SetActive(true);

        disableAll();
        detectPanel.SetActive(true);

        cameraManagerScript.EnableARCamera();
        ManageCamera(true);

        placeIndicator.gameObject.SetActive(true);

    }

    public void arActive()
    {
        disableAll();

        //cameraManagerScript.EnableARCamera();
        //ManageCamera(true);

        arPanel.SetActive(true);
    }


    public void PlaceAgain()
    {
        destroyDevin();
        detectActive();
    }

    public void dashboardActive()
    {
        disableAll();
        dashboard.SetActive(true);
        destroyDevin();
        ManageCamera(false);
    }

    public void ProfileActive()
    {
        disableAll();
        profile.SetActive(true);
    }    
    
    public void ProfileEditActive()
    {
        disableAll();
        profileEdit.SetActive(true);
    }

    public void disableAll()
    {


        //arCamera.gameObject.SetActive(false);
        //arCamera.enabled = false;
        //xrOrigin.SetActive(false);

        placeIndicator.gameObject.SetActive(false);

        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        login.SetActive(false);
        register.SetActive(false);
        detectPanel.SetActive(false);
        arPanel.SetActive(false);
        dashboard.SetActive(false);
        profileEdit.SetActive(false);
        profile.SetActive(false);

    }

    public void destroyDevin()
    {
        newPlacedObject = placeManager.GetNewPlacedObject();
        if (newPlacedObject != null)
        {
            Destroy(newPlacedObject);
        }
    }

    private void ManageCamera(bool state)
    {
        if(state == true)
        {
            cameraManagerScript.EnableARCamera();
        }
        else
        {
            cameraManagerScript.DisableARCamera();
        }
    }

}
