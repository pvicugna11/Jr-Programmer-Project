using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;
    public static Color cubeColor = new Color(0f, 1f, 1f, 1f);

    public void NewColorSelected(Color color)
    {
        cubeColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveColorClicked()
    {

    }

    public void LoadColorCliked()
    {

    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
