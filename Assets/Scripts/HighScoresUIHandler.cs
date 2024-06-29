using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HightScoresUIHandler : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI easyScoreText;
    [SerializeField]
    TextMeshProUGUI mediumScoreText;
    [SerializeField]
    TextMeshProUGUI hardScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SettingsManager.BestScore bestScore = SettingsManager.Instance.bestScore;
        if (bestScore.bestScoreEasy.bestScore == 0)
        {
            easyScoreText.text = "Not beaten";
        }
        else
        {
            easyScoreText.text = $"Player: {bestScore.bestScoreEasy.playerName} - Score: {bestScore.bestScoreEasy.bestScore}";
        }
        if (bestScore.bestScoreMedium.bestScore == 0)
        {
            mediumScoreText.text = "Not beaten";
        }
        else
        {
            mediumScoreText.text = $"Player: {bestScore.bestScoreMedium.playerName} - Score: {bestScore.bestScoreMedium.bestScore}";
        }
        if (bestScore.bestScoreHard.bestScore == 0)
        {
            hardScoreText.text = "Not beaten";
        }
        else
        {
            hardScoreText.text = $"Player: {bestScore.bestScoreHard.playerName} - Score: {bestScore.bestScoreHard.bestScore}";
        }
    }
    public void CloseHighScores()
    {
        SceneManager.LoadScene("Menu");
    }
}
