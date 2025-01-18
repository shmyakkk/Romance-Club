using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class AuthManager : MonoBehaviour
{
    [SerializeField] private TMP_Text unicID;

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        if (AuthenticationService.Instance.IsSignedIn)
        {
            unicID.text = AuthenticationService.Instance.PlayerId;
        }
        else
        {
            SignIn();
        }
    }

    public async void SignIn()
    {
        await signInAnonimus();
    }

    async Task signInAnonimus()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            unicID.text = AuthenticationService.Instance.PlayerId;
        }
        catch (AuthenticationException ex)
        {
            print("Sign in failed!");
            Debug.LogException(ex);
        }
    }

    async Task signInWithFacebook(string token)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithFacebookAsync(token);
        }
        catch (AuthenticationException ex)
        {
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogException(ex);
        }
    }
}