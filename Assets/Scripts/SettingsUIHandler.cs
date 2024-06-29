using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class SettingsUIHandler : MonoBehaviour
{

    [SerializeField] TMP_Dropdown difficultyDropdown;
    [SerializeField] TMP_Dropdown colorDropdown;

    // Start is called before the first frame update
    void Start()
    {
        difficultyDropdown.onValueChanged.AddListener(delegate
        {
            DifficultyChanged();
        });
        difficultyDropdown.value = ((int)SettingsManager.Instance.Difficulty);

        colorDropdown.onValueChanged.AddListener(delegate
        {
            ColorChanged();
        });
        colorDropdown.value = ((int)SettingsManager.Instance.BallColor);
    }
    public void CloseSettings()
    {
        SceneManager.LoadScene("Menu");
        SettingsManager.Instance.SaveSettings();
    }
    public void NewColorSelected(BallColor color)
    {
        // add code here to handle when a color is selected
        SettingsManager.Instance.BallColor = color;
    }
    private void DifficultyChanged()
    {
        var difficulty = (Difficulty)difficultyDropdown.value;
        Debug.Log($"Changed difficulty to: {difficulty}");
        SettingsManager.Instance.Difficulty = difficulty;
    }
    private void ColorChanged()
    {
        var color = (BallColor)colorDropdown.value;
        Debug.Log($"Changed color to: {color}");

        SettingsManager.Instance.BallColor = color;
    }
    public enum Difficulty
    {
        EASY,MEDIUM, HARD
    }
    public enum BallColor
    {
        RED,GREEN, BLUE
    }
}