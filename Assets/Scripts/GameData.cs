using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Some important variables of the game are defined in this class. This class shows the number
//of collected masks and also shows the player’s score.Also, it checks if the game is finished or not.

//for GameData
public class GameData : MonoBehaviour
{
    public static int collectedMGs = 0;
    public static int difficultyLevel = 0;
    public Text collectedMGnum , hitedMask;
    public static bool GameOver = false;
    public static int health = 3;
    public static int hitedMaskNumber = 0;

    // Update is called once per frame
    void Update()
    {
        collectedMGnum.text = collectedMGs.ToString();
        hitedMask.text = hitedMaskNumber.ToString();
        if(health <= 0)
        {
            GameOver = true;
            PlayerPrefs.SetInt("finalScore", hitedMaskNumber);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
