using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//In this class, the difficulty of the game changes after passing certain meters by the player.

//for player prefab
public class Score : MonoBehaviour
{
    private float score = 0.0f;
    //public Text scoreText;

    private int maxDifficultyLevel = 50;
    private int scoreToNextLevel = 4;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(score >= scoreToNextLevel)
        {
            LevelUp();
            scoreToNextLevel += scoreToNextLevel;
        }
        score = PlayerMotor.meters;
        //scoreText.text = ((int)score).ToString();
    }
    void LevelUp()
    {
        if(GameData.difficultyLevel < maxDifficultyLevel)
        {
            GameData.difficultyLevel++;
        }

    }
}
