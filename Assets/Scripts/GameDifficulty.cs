using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDifficulty : MonoBehaviour
{
    public static float DifficultyMultiplier;
    public TextMeshProUGUI DifficultyIndicator;
    public Slider DifficultySlider;

    public static GameDifficulty gameDifficulty_instance;

    private void Awake()
    {
        if (gameDifficulty_instance == null)
        {
            gameDifficulty_instance = this;
            StaticData.EnemyHPMultiplier = 1f;
            StaticData.EnemySpeedMultiplier = 1f;
            StaticData.GameDifficultyMultiplier = 1f;
            StaticData.EnemyCounterMultiplier = 1;
        }

        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void OnValueChanged()
    {

        DifficultyMultiplier = DifficultySlider.value / 10;
        DifficultyIndicator.text = "Difficulty multiplier : " + DifficultyMultiplier;
        StaticData.GameDifficultyMultiplier = DifficultyMultiplier;
        StaticData.EnemyCounterMultiplier = (int)DifficultyMultiplier;
        StaticData.EnemyHPMultiplier = DifficultyMultiplier/2;
        StaticData.EnemyHPMultiplier = Mathf.Clamp(StaticData.EnemyHPMultiplier, 1f, 2.5f);
        //Debug.Log(StaticData.EnemyHPMultiplier);
        //Debug.Log(StaticData.EnemyCounterMultiplier);
        //Debug.Log(StaticData.GameDifficultyMultiplier);

    }
}
