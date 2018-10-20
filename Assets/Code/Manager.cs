using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private const string BetweenLevelsMenu = "BetweenLevelsMenu";
    public Transform EnvSphere;
    public Button NextLevelButton;

    private static Manager instance;
    private static int currentLevel;

    public static Manager getInstance()
    {
        return instance;
    }

    // Use this for initialization
    private void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        GameObject.DontDestroyOnLoad(gameObject);
        instance = this;
        Instantiate(EnvSphere, GetComponent<Transform>());
    }

    public void GotoLocation(string location)
    {
        if (string.IsNullOrEmpty(location) || location == "exit")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
        }
        else
        {
            SceneManager.LoadScene(location);
            Scene scene = SceneManager.GetSceneByName(location);
            LoadScene(scene.buildIndex);
        }
    }

    public void GotoNextLevel()
    {
        int buildIndex = currentLevel + 1;
        SceneManager.LoadScene(buildIndex);
        LoadScene(buildIndex);
    }
    
    private void LoadScene(int level)
    {   
        currentLevel = level;
    }

    public void ShowNextLevelMenu()
    {
        SceneManager.LoadScene(BetweenLevelsMenu);
        int nextLevel = currentLevel + 1;
        NextLevelButton.interactable = SceneManager.sceneCountInBuildSettings > nextLevel;
    }
}