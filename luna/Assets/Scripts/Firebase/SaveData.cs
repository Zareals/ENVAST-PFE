using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

public class SaveData : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBReference;

    public int score;

    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveScore(int Cloudscore)
    {
        StartCoroutine(UpdateScore(Cloudscore));
    }

    private IEnumerator UpdateScore(int score)
    {
        var DBtask = DBReference.Child("users").Child(User.UserId).Child("Experience").SetValueAsync(score);

        yield return new WaitUntil(predicate: () => DBtask.IsCompleted);

        if (DBtask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register Task with {DBtask.Exception}");
        }
        else
        {
            //Update PLayer Experience
        }

    }
}
