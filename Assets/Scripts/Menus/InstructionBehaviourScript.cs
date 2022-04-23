using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionBehaviourScript : MonoBehaviour
{
    public GameObject[] pages;
    public int index;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        index = 0;
    }
    public void OnReturnButtonClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnNextButtonClicked()
    {
        if (index == 4)
            return;

        pages[index].SetActive(false);
        index++;
        pages[index].SetActive(true);
    }
    public void OnPreviousButtonClicked()
    {
        if (index == 0)
            return;

        pages[index].SetActive(false);
        index--;
        pages[index].SetActive(true);
    }
}
