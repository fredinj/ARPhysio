using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using Firebase.Extensions;

public class UserManagerScript : MonoBehaviour
{

    //
    //
    // work in progress, only used to trigger login for now
    //
    //


    // user related variables

    public TMP_InputField loginEmailField;
    public TMP_InputField loginPasswordField;
    public TMP_InputField signupEmailField;
    public TMP_InputField signupPasswordField;
    public TMP_InputField signupConfirmField;

    // data store
    public DataStoreScript dataStore;

    // other variables
    GameManagerScript gameManager;
    TriggerScript triggerScript;

    private FirebaseAuth auth;


    private void Start()
    {
        // change to reference from unity ui?
        triggerScript = FindObjectOfType<TriggerScript>();
        auth = FirebaseAuth.DefaultInstance;
    }


    public void StartUserManagement()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        FirebaseUser user = auth.CurrentUser;

        Debug.Log("User Management Started");

        gameManager = FindObjectOfType<GameManagerScript>();


        if (user != null)
        {
            // If it exists, get its value
            dataStore.isUserLoggedIn = true;

            Debug.Log("login flag exists");
        }
        else
        {
            Debug.Log("login flag doesn't exist");

            dataStore.isUserLoggedIn = false;
            dataStore.userName = "";

            LogoutUser();
        }

        if (dataStore.isUserLoggedIn)
        {
            //dataStore.userName = PlayerPrefs.GetString("userName");

            dataStore.userName = user.Email;
            triggerScript.detectActive();
        }
        else
        {
            dataStore.userName = "";
            triggerScript.intro1Active();
        }
    }

    #region signup
    public void RegisterUser()
    {
        string email = signupEmailField.text; // Get the email from the input field
        string password = signupPasswordField.text; // Get the password from the input field
        string confirm = signupConfirmField.text; // Get the confirm password from the input field

        if (password == confirm)
        {
            Debug.Log("Passwords match");

            auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                // Firebase user has been created.

                AuthResult result = task.Result;

                //FirebaseUser newUser = task.Result.User;

                Debug.LogFormat("User Registered successfully: {0})", result.User.Email);

                // remove text from fields


                if (result.User.IsEmailVerified)
                {
                    Debug.Log("Signed Up Successfully");
                }
                else
                {
                    Debug.Log("Please verify your email");
                    SendEmailVerification();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        else
        {
            Debug.Log("Passwords do not match");
        }
    }

    public void SendEmailVerification()
    {
        StartCoroutine(SendEmailForVerificationAsync());
    }


    IEnumerator SendEmailForVerificationAsync()
    {
        Debug.Log("SendEmailForVerificationAsync called");

        FirebaseUser user = FirebaseAuth.DefaultInstance.CurrentUser;
        if (user != null)
        {
            var sendEmailTask = user.SendEmailVerificationAsync();
            float timeout = 10f; // 10 seconds
            float timer = 0f;

            while (!sendEmailTask.IsCompleted && timer < timeout)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            if (sendEmailTask.Exception != null)
            {
                // Handle the exception
                FirebaseException firebaseException = sendEmailTask.Exception.GetBaseException() as FirebaseException;
                AuthError error = (AuthError)firebaseException.ErrorCode;
                Debug.LogError($"Email verification failed: {error}");
            }
            else if (timer >= timeout)
            {
                Debug.LogError("Email verification timed out");
            }
            else
            {
                Debug.Log("Email verification sent successfully");
                triggerScript.loginActive();
            }
        }
        else
        {
            Debug.Log("User Not Found");
        }
    }

    #endregion


    #region login
    public void LoginUser()
    {


        #region old deprecated
/*        string userName = loginUsernameField.text;
        string password = loginPasswordField.text;
        if (userName != "" && password != "")
        {
            dataStore.isUserLoggedIn = true;
            dataStore.userName = userName;
            dataStore.userPassword = password;

            PlayerPrefs.SetString("userName", userName);
            PlayerPrefs.SetInt("isUserLoggedIn", 1);
            PlayerPrefs.Save();

            triggerScript.disableAll();
            detectPanel.SetActive(true);

            triggerScript.detectActive();

        }
        else
        {
            gameManager.ShowToast("Invalid username or password");
        }*/
        #endregion


        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        string email = loginEmailField.text;
        string password = loginPasswordField.text;

        Credential credential = EmailAuthProvider.GetCredential(email, password);
        auth.SignInAndRetrieveDataWithCredentialAsync(credential).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAndRetrieveDataWithCredentialAsync was canceled.");
                return;
            }

            if (task.IsFaulted)
            {
                FirebaseException firebaseException = task.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseException.ErrorCode;

                switch (errorCode)
                {
                    case AuthError.InvalidEmail:
                        Debug.LogError("Invalid email address");
                        break;
                    case AuthError.WeakPassword:
                        Debug.LogError("Weak password");
                        break;
                    default:
                        Debug.LogError("SignInAndRetrieveDataWithCredentialAsync encountered an error: " + task.Exception);
                        break;
                }

                return;
            }

            // Get the result of the asynchronous operation
            AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);

            if (!result.User.IsEmailVerified)
            {
                Debug.Log("Please verify email!!");
            }

            else if (task.IsCompleted)
            {
                Debug.Log("User Signed In successfully");

                triggerScript.detectActive();
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    #endregion




    public void LogoutUser()
    {
        dataStore.isUserLoggedIn = false;
        dataStore.userName = "";

        auth.SignOut();


        /*        disableUi();
                intro1.SetActive(true);*/

        triggerScript.intro1Active();
    }
}
