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
            // Este error puede surgir por varias razones, pero generalmente se debe a problemas con las credenciales de autenticación,
            // a problemas con la configuración de la autenticación en el juego o
            // a un problema con el proveedor de identidad con el que se está intentando iniciar sesión.
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex) 
        {
            //Este es el erro más común cuando por ejemplo metes el usuario bien
            //pero la contraseña no o cuando ambos campos son erróneos.
            
            Debug.LogException(ex);
            Debug.Log("Ha ocurrido un error. Inténtelo de nuevo.");

        }
    }
}
