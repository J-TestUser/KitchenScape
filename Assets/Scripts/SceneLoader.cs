using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string sceneName)//string SceneName es un parametro que nos permite determinar que queremos, en este caso, un string corrspondiente al nombre de una escena.
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); //salir del juego cantes de la build final (dentro del editor de unity)

        #else
        Application.Quit(); //Salir del juego en el juego final
        #endif
    }
}
