using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerHUDScript : MonoBehaviour
{
    public TextMeshProUGUI timerUI, currentLevelUI, subtitleUI;
    public GameObject pauseUI;
    public AudioSource beep, deadBeep;

    private float maxTime = 10f;
    public float currentTime = 10f;
    public float beepTime = 0f;


    public int currentLevel;
    public bool isTimerRunning;
    private string nextLevel;



    // Start is called before the first frame update
    void Start()
    {
        currentLevelUI.text = "Level " + currentLevel;
        nextLevel = "Level" + (currentLevel + 1) + "Scene";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if (!isTimerRunning) return;

        if(currentTime <= 0)
        {
            print("you died");
            SceneManager.LoadScene("LoseScene");
            return;
        }
        //Slightly longer than 10s so player won't be too rushed
        currentTime = currentTime - (Time.deltaTime * 0.9f);

        timerUI.text = Mathf.Round(currentTime).ToString();

        beepTime += Time.deltaTime * 0.9f;
        if(beepTime >= 1)
        {
            if(currentTime <= 1)
                deadBeep.Play();
            else if (currentTime > 1)
            {
                beep.Play();
            }
            print("beep");
            beepTime = 0;
        }
    }

    public void WinLevel()
    {
        isTimerRunning = false;
        print("You Win");
        //advance to next level here
        if (currentLevel != 8)
            SceneManager.LoadScene(nextLevel);
        else
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    public void OnLButton(InputValue value)
    {
            isTimerRunning = false;
    }

    public void OnPause(InputValue value)
    {
        if(value.isPressed)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnPauseUIResumeButtonClicked()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnPauseUIReturnButtonClicked()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("MainMenuScene");
    }
}
