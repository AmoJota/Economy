using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour
{
    [SerializeField] TMP_InputField userField, passwordField;
    string user = "";
    string pass = "";

    public async void CatchInfoPlayer()
    {
        user = userField.text;
        pass = passwordField.text;

        await SignUpWithUsernamePasswordAsync(user, pass);

        PlayerPrefs.SetString("UserName",user);
    }

    public async Task SignUpWithUsernamePasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            SceneManager.LoadScene(1);

            Debug.Log("SignUp is successful.");

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
