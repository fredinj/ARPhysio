using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserManagerScript : MonoBehaviour
{

    //
    //
    // work in progress, only used to trigger login for now
    //
    //


    // user related variables

    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    // data store
    public DataStoreScript dataStore;

    // other variables
    GameManagerScript gameManager;
    TriggerScript triggerScript;

    private void Start()
    {
        // change to reference from unity ui?
        triggerScript = FindObjectOfType<TriggerScript>();
    }


    public void StartUserManagement()
    {
        Debug.Log("User Management Started");

        gameManager = FindObjectOfType<GameManagerScript>();


        if (PlayerPrefs.HasKey("isUserLoggedIn"))
        {
            // If it exists, get its value
            dataStore.isUserLoggedIn = PlayerPrefs.GetInt("isUserLoggedIn") == 1 ? true : false;

            Debug.Log("login flag exists");
        }
        else
        {
            Debug.Log("login flag doesn't exist");

            dataStore.isUserLoggedIn = false;
            dataStore.userName = "";
            dataStore.userPassword = "";

            PlayerPrefs.SetInt("isUserLoggedIn", 0);
            PlayerPrefs.Save();

            LogoutUser();
        }

        if (dataStore.isUserLoggedIn)
        {
            dataStore.userName = PlayerPrefs.GetString("userName");
            triggerScript.detectActive();
        }
        else
        {
            dataStore.userName = "";
            triggerScript.intro1Active();
        }
    }

    void Update()
    {
        
    }


    public void LoginUser()
    {
        string userName = usernameField.text;
        string password = passwordField.text;


        if (userName != "" && password != "")
        {
            dataStore.isUserLoggedIn = true;
            dataStore.userName = userName;
            dataStore.userPassword = password;

            PlayerPrefs.SetString("userName", userName);
            PlayerPrefs.SetInt("isUserLoggedIn", 1);
            PlayerPrefs.Save();

            /*            triggerScript.disableAll();
                        detectPanel.SetActive(true);*/

            triggerScript.detectActive();

        }
        else
        {
            gameManager.ShowToast("Invalid username or password");
        }
    }

    public void LogoutUser()
    {
        dataStore.isUserLoggedIn = false;
        dataStore.userName = "";
        dataStore.userPassword = "";
        PlayerPrefs.SetInt("isUserLoggedIn", 0);
        PlayerPrefs.Save();

        /*        disableUi();
                intro1.SetActive(true);*/

        triggerScript.intro1Active();
    }
}
