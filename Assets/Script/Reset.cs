using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void ResetCurrentScene()
    {
        SceneManager.LoadScene("MainMenu");

        //*Reset*//
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
    }
}
