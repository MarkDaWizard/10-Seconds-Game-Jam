using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class SoundManagerScript : MonoBehaviour
{
    private string currentScene = "MainMenuScene";
    public AudioSource menuMusic, defeatMusic, victoryMusic, gameMusic;

    //Check to see if there's only 1 Manager
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Audio");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //mixer = GetComponent<AudioMixer>();

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        //PlayBGM();
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        currentScene = scene.name;
        PlayBGM();
    }

    private List<AudioSource> allAudioSources;
    //Stop all music
    void StopAllMusic()
    {

        allAudioSources = new List<AudioSource>(FindObjectsOfType(typeof(AudioSource)) as AudioSource[]);
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    public void PlayBGM()
    {
        switch (currentScene)
        {
            case ("MainMenuScene"):
                Debug.Log("menu");
                if (victoryMusic.isPlaying || defeatMusic.isPlaying || gameMusic.isPlaying)
                    StopAllMusic();
                if (!menuMusic.isPlaying)
                    menuMusic.Play();
                break;
            case ("CreditsScene"):
                Debug.Log("menu");
                if (!menuMusic.isPlaying)
                    menuMusic.Play();
                break;
            case ("InstructionScene"):
                Debug.Log("menu");
                if (!menuMusic.isPlaying)
                    menuMusic.Play();
                break;
            case "LoseScene":
                StopAllMusic();
                defeatMusic.Play();
                break;
            case "WinScene":
                Debug.Log("win");
                StopAllMusic();
                victoryMusic.Play();
                break;
            case "Level1Scene":
                StopAllMusic();
                gameMusic.Play();
                break;
            default:
                if (!gameMusic.isPlaying)
                    gameMusic.Play();
                break;
        }
    }

    }
