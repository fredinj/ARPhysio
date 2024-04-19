using Firebase.Firestore;
using UnityEngine;
using Firebase.Auth;
using System.Threading.Tasks;

[FirestoreData]
public class UserData
{
    [FirestoreProperty]
    public string userName { get; set; }
    [FirestoreProperty]
    public string email { get; set; }
    [FirestoreProperty]
    public string firstName { get; set; }
    [FirestoreProperty]
    public string lastName { get; set; }
    [FirestoreProperty]
    public string phone { get; set; }
    [FirestoreProperty]
    public string gender { get; set; }
}

public class FirestoreManager : MonoBehaviour
{
    public UserData userData; // Public static field to store UserData

    FirebaseAuth auth;
    FirebaseFirestore db;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        db = FirebaseFirestore.DefaultInstance;
    }


    public async void FirebaseInit()
    {
        Debug.Log("Initializing Firestore...");

        // Check if user is logged in
        if (auth.CurrentUser != null)
        {
            await GetUserDetails(auth.CurrentUser.Email);
        }
        else
        {
            Debug.LogError("User is not logged in.");
        }
    }

    public async Task GetUserDetails(string userEmail)
    {
        // Check if document with user's email exists
        DocumentSnapshot snapshot = await db.Collection("user-data").Document(userEmail).GetSnapshotAsync();

        if (snapshot.Exists)
        {
            // Document exists, read data into object
            userData = snapshot.ConvertTo<UserData>();
            // Now you can use userData

/*            Debug.Log("User Data retrieved:");
            Debug.Log("Username: " + userData.userName);
            Debug.Log("Email: " + userData.email);
            Debug.Log("First Name: " + userData.firstName);
            Debug.Log("Last Name: " + userData.lastName);
            Debug.Log("Phone: " + userData.phone);
            Debug.Log("Gender: " + userData.gender);*/

        }
        else
        {
            // Document doesn't exist, initialize object with default values
            userData = new UserData
            {
                userName = auth.CurrentUser.DisplayName, // Get username from Firebase Auth
                email = userEmail,
                firstName = "", // Set additional fields as needed
                lastName = "",
                phone = "",
                gender = ""
            };

            // Store the initialized object
            await db.Collection("user-data").Document(userEmail).SetAsync(userData);
        }
    }

    public async Task StoreFirestore()
    {
        if (auth.CurrentUser != null)
        {
            string userEmail = auth.CurrentUser.Email;
            // Implement storing data to Firestore
            await db.Collection("user-data").Document(userEmail).SetAsync(userData);
        }
        else
        {
            Debug.LogError("User is not logged in.");
        }
    }


    public void readFirestore()
    {
        // Implement reading data from Firestore
    }
}
