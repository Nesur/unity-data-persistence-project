using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    TMP_InputField playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        playerNameInput.onValueChanged.AddListener(delegate
        {
            SavePlayerName();
        });
        playerNameInput.text = SettingsManager.Instance.playerName;
    }
    private void SavePlayerName()
    {
        SettingsManager.Instance.playerName = playerNameInput.text;
    }
    public void StartGame()
    {
        if (SettingsManager.Instance.playerName != "")
        {
            SceneManager.LoadScene("main");
        }
    }
    public void OpenSettings() { 
        SceneManager.LoadScene("Settings");
    }
    public void OpenBestScores() { 
        SceneManager.LoadScene("BestScores");
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }
}
