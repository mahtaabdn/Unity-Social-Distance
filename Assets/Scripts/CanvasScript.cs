using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//This class is associated with the final canvas. In case the new score is more than the previous
//highest score, it changes it.Also, there are two functions in this class for the Restart button
//and the Quit button.
public class CanvasScript : MonoBehaviour
{
    public GameObject QuitButton, RestartButton, DonateText, ScoreImage, HighScoreImage;
    public Text scoreText, highScoreText;
    private int finalScore;
    public static int highScore = 0;
    public AudioSource butt;
    public AudioClip Aud;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = PlayerPrefs.GetInt("finalScore");
        scoreText.text = finalScore.ToString();
        if(highScore < finalScore)
        {
            highScore = finalScore;
        }
        highScoreText.text = highScore.ToString();
    }

    public void QuitB()
    {
        butt.PlayOneShot(Aud);
        Application.Quit();
    }
    public void RestartB()
    {
        butt.PlayOneShot(Aud);
        GameData.collectedMGs = 0;
        GameData.difficultyLevel = 0;
        GameData.GameOver = false;
        GameData.health = 3;
        GameData.hitedMaskNumber = 0;
        PlayerMotor.isSent = false;
        PlayerMotor.flyEnd = false;
        PlayerMotor.becomeAngel = false;
        PlayerMotor.downingTime = false;
        PlayerMotor.destAngMask = false;
        SpawnAngel.fly = false;
        AmbAnim.menuTime = false;
        CollectMG.delMG = false;
        AngelTime.spawnOnce = false;
        CollectAngel.angelTime = false;
        PlayerMotor.meters = 0;
        //ShootDir.animOn = false;
        SceneManager.LoadScene("MainScene");
    }
}
