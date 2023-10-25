using TMPro;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] TMP_InputField userField, passwordField;
    string user = "";
    string pass = "";

    public async void CatchInfoPlayer()
    {
        user = userField.text;
        pass = passwordField.text;

        await SignInWithUsernamePasswordAsync(user, pass);
        PlayerPrefs.SetString("UserName", user);

    }
    private async Task SignInWithUsernamePasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            SceneManager.LoadScene(1);

            Debug.Log("SignIn is successful.");

        }
        catch (AuthenticationException ex)
        {
            // Este error puede surgir por varias razones, pero generalmente se debe a problemas con las credenciales de autenticaci�n,
            // a problemas con la configuraci�n de la autenticaci�n en el juego o
            // a un problema con el proveedor de identidad con el que se est� intentando iniciar sesi�n.
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex) 
        {
            //Este es el erro m�s com�n cuando por ejemplo metes el usuario bien
            //pero la contrase�a no o cuando ambos campos son err�neos.
            
            Debug.LogException(ex);
            Debug.Log("Ha ocurrido un error. Int�ntelo de nuevo.");

        }
    }
}
