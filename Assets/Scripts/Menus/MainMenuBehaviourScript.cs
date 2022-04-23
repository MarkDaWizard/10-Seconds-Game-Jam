using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviourScript : MonoBehaviour
{

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    public void OnInstructionButtonClicked()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void OnCreditsButtonClicked()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

}
