using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static SettingsUIHandler;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    public string playerName;
    public BestScore bestScore = new BestScore();
    public BallColor BallColor = BallColor.RED;
    public SettingsUIHandler.Difficulty Difficulty = SettingsUIHandler.Difficulty.EASY;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadSettings();
    }
    public void SaveSettings()
    {
        SettingsData settingsData = new SettingsData();
        settingsData.bestScore = bestScore;
        settingsData.Difficulty = Difficulty;  
        settingsData.BallColor = BallColor;
        var json = JsonUtility.ToJson(settingsData);
        var savePath = $"{Application.persistentDataPath}/savedata.json";
        File.WriteAllText(savePath, json);
    }
    public void LoadSettings()
    {
        var savePath = $"{Application.persistentDataPath}/savedata.json";
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SettingsData settingsData = JsonUtility.FromJson<SettingsData>(json);
            bestScore = settingsData.bestScore;
            BallColor = settingsData.BallColor;
            Difficulty = settingsData.Difficulty;
        }
    }

    public void StoreBestScore(int score)
    {
        switch (Difficulty)
        {
            case SettingsUIHandler.Difficulty.EASY:
                bestScore.bestScoreEasy.bestScore = score;
                bestScore.bestScoreEasy.playerName = playerName;
                break;
            case SettingsUIHandler.Difficulty.MEDIUM:
                bestScore.bestScoreMedium.bestScore = score;
                bestScore.bestScoreMedium.playerName = playerName;
                break;
            case SettingsUIHandler.Difficulty.HARD:
                bestScore.bestScoreHard.bestScore = score;
                bestScore.bestScoreHard.playerName = playerName;
                break;
        }
    }
    public bool IsBestScoreBeaten(int score)
    {
        switch (Difficulty)
        {
            case SettingsUIHandler.Difficulty.EASY:
                return score > bestScore.bestScoreEasy.bestScore;
            case SettingsUIHandler.Difficulty.MEDIUM:
                return score > bestScore.bestScoreMedium.bestScore;
            case SettingsUIHandler.Difficulty.HARD:
                return score > bestScore.bestScoreHard.bestScore;
        }
        return false;
    }

    [Serializable]
    private class SettingsData 
    {
        public BestScore bestScore;
        public BallColor BallColor;
        public SettingsUIHandler.Difficulty Difficulty;
    }
    [Serializable]
    public class BestScore
    {
        public PlayerBestScore bestScoreEasy;
        public PlayerBestScore bestScoreMedium;
        public PlayerBestScore bestScoreHard;
    }
    [Serializable]
    public class PlayerBestScore
    {
        public string playerName;
        public int bestScore = 0;
    }
}
