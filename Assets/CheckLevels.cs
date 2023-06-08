using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLevels : MonoBehaviour
{
    //This script is for loading the minigames. It should only be loaded when the server has more then 2 minutes left on the clock.
    public RFIDReader RFIDReaderScript;
    public ParticleSystem Confetti;
    AudioSource YouWin;

    public bool Level1Reached = false;
    public bool Level2Reached = false;
    public bool Level3Reached = false;
    public bool Level4Reached = false;
    public bool Level5Reached = false;

    public Canvas TextCanvas;

    // Start is called before the first frame update
    void Start()
    {
        YouWin = gameObject.GetComponent<AudioSource>();

    }

    public void Chapter1() //Chapter 2
    {
        if (!Level1Reached)
        {
            Confetti.Play();
            YouWin.Play();
            StartCoroutine(TextMinigames1(4f));
            Level1Reached = true;
        }
      
    }

    public void Chapter2() //Chapter 3
    {
        if (!Level2Reached)
        {
            Confetti.Play();
            YouWin.Play();
            StartCoroutine(TextMinigames2(4f));
            Level2Reached = true;
            
        }

    }

    public void Chapter3() //Chapter 4
    {
        if (!Level3Reached)
        {
            Confetti.Play();
            YouWin.Play();
            StartCoroutine(TextMinigames3(4f));
            Level3Reached = true;
        }

    }

    public void Chapter4() //Chapter 1
    {
        if (!Level4Reached)
        {
            Confetti.Play();
            YouWin.Play();
            StartCoroutine(TextMinigames4(4f));
            Level4Reached = true;
            
        }

    }


    private IEnumerator TextMinigames1(float textTime)
    {
        RFIDReaderScript.waitForMinigame2 = true;
        RFIDReaderScript.waitForMinigame3 = true;
        RFIDReaderScript.waitForMinigame4 = true;

        TextCanvas.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(0).gameObject.SetActive(false);
        TextCanvas.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(1).gameObject.SetActive(false);
        TextCanvas.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(2).gameObject.SetActive(false);
        RFIDReaderScript.waitForMinigame2 = false;
        RFIDReaderScript.waitForMinigame3 = false;
        RFIDReaderScript.waitForMinigame4 = false;

    }

    private IEnumerator TextMinigames2(float textTime)
    {
        RFIDReaderScript.waitForMinigame1 = true;
        RFIDReaderScript.waitForMinigame3 = true;
        RFIDReaderScript.waitForMinigame4 = true;

        TextCanvas.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(0).gameObject.SetActive(false);
        TextCanvas.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(1).gameObject.SetActive(false);
        TextCanvas.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(2).gameObject.SetActive(false);
        RFIDReaderScript.waitForMinigame1 = false;
        RFIDReaderScript.waitForMinigame3 = false;
        RFIDReaderScript.waitForMinigame4 = false;

    }

    private IEnumerator TextMinigames3(float textTime)
    {
        RFIDReaderScript.waitForMinigame1 = true;
        RFIDReaderScript.waitForMinigame2 = true;
        RFIDReaderScript.waitForMinigame4 = true;
 
        TextCanvas.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(0).gameObject.SetActive(false);
        TextCanvas.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(1).gameObject.SetActive(false);
        TextCanvas.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(2).gameObject.SetActive(false);
        RFIDReaderScript.waitForMinigame1 = false;
        RFIDReaderScript.waitForMinigame2 = false;
        RFIDReaderScript.waitForMinigame4 = false;

    }

    private IEnumerator TextMinigames4(float textTime)
    {
        RFIDReaderScript.waitForMinigame1 = true;
        RFIDReaderScript.waitForMinigame2 = true;
        RFIDReaderScript.waitForMinigame3 = true;
 
        TextCanvas.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(0).gameObject.SetActive(false);
        TextCanvas.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(1).gameObject.SetActive(false);
        TextCanvas.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        TextCanvas.transform.GetChild(2).gameObject.SetActive(false);
        RFIDReaderScript.waitForMinigame1 = false;
        RFIDReaderScript.waitForMinigame2 = false;
        RFIDReaderScript.waitForMinigame3 = false;

        SceneManager.LoadScene("Minigame1");

    }
}
