using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This class is written to manage the start canvas, by defining two functions for two buttons
//of the canvas.The function for the first button, change the text, and the second function changes the scene.

//for start scene canvas
public class StartScript : MonoBehaviour
{
    public GameObject text, okbutton, text1, playbut;
    public AudioSource butt;
    public AudioClip Aud;
    private void Start()
    {
        text1.SetActive(false);
        playbut.SetActive(false);
    }
    public void OKButton()
    {
        butt.PlayOneShot(Aud);
        text.SetActive(false);
        text1.SetActive(true);
        okbutton.SetActive(false);
        playbut.SetActive(true);
    }
    public void StartBut()
    {
        butt.PlayOneShot(Aud);
        SceneManager.LoadScene("TutorialScene");
    }
}
