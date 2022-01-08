using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;
    public static Color CubeColor;

    public void NewColorSelected(Color color)
    {
        CubeColor = color;
    }
    
    private void Start()
    {
        LoadCubeColor();
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    private void LoadCubeColor()
    {
        float r = PlayerPrefs.GetFloat("RED", 0f);
        float g = PlayerPrefs.GetFloat("GREEN", 1f);
        float b = PlayerPrefs.GetFloat("BLUE", 1f);
        float a = PlayerPrefs.GetFloat("ALPHA", 1f);

        CubeColor = new Color(r, g, b, a);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveColorClicked()
    {
        PlayerPrefs.SetFloat("RED", CubeColor.r);
        PlayerPrefs.SetFloat("GREEN", CubeColor.g);
        PlayerPrefs.SetFloat("BLUE", CubeColor.b);
        PlayerPrefs.SetFloat("ALPHA", CubeColor.a);
        PlayerPrefs.Save();
    }

    public void LoadColorCliked()
    {
        LoadCubeColor();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
