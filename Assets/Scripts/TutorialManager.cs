using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This class is used in TutorialScene. In this class, a function for the ok button is defined. This
//function manages the texts of the canvas and also creates prefabs that are used in the game
//and destroy them after representing their functionality.
public class TutorialManager : MonoBehaviour
{
    public GameObject textpeople, okbutton, textmask, textsend, textangel, personOb, angelOb,maskOb, shootBut;
    public AudioSource butt;
    public AudioClip Aud;
    private int tutNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        textangel.SetActive(false);
        textmask.SetActive(false);
        textsend.SetActive(false);
        shootBut.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextBut()
    {
        butt.PlayOneShot(Aud);

        if (tutNum == 3)
        {
            SceneManager.LoadScene("MainScene");
        }

        if (tutNum == 2)
        {
            textsend.SetActive(false);
            textangel.SetActive(true);
            shootBut.SetActive(false);
            Instantiate(angelOb);
            tutNum++;
        }
        if (tutNum == 1)
        {
            textmask.SetActive(false);
            textsend.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Tm"));
            shootBut.SetActive(true);
            tutNum++;
        }
        if (tutNum == 0)
        {
            textpeople.SetActive(false);
            textmask.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Tp"));
            Instantiate(maskOb);
            tutNum++;
        }

    }
}
