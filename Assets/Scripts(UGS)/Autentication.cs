using System;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using TMPro;

public class Autentication : MonoBehaviour
{
    [SerializeField] TMP_Text userExistText;
    private async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        SetupEvents();

        Debug.Log(UnityServices.State);       
   }
    void SetupEvents()
    {
        AuthenticationService.Instance.SignedIn += () => {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");

        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            //Debug.LogError(err);
            userExistText.text = "El usuario que has introducido ya existe...";
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };

        AuthenticationService.Instance.Expired += () =>
        {
            Debug.Log("Player session could not be refreshed and expired.");
        };
    } 
}
