using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    public void PlayGameButton()
    {
       SceneManager.LoadScene("Game");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
