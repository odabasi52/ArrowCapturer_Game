using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highscoreText;
    int highscore = 0;
    [SerializeField] Slider health;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Animator anim;
    [SerializeField] Animator animStart;

    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip whoosh;

    public static float Health;

    void Start()
    {
        scoreText.text = "score - 00";

        highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "highscore - " + highscore.ToString("00");

        Health = 30;
        health.maxValue = Health;

        gameOverScreen.SetActive(false);
    
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    void Update()
    {
        health.value = Health;

        scoreText.text = "score - " + TriggerController.score.ToString("00");

        if(highscore < TriggerController.score)
        {
            highscore = TriggerController.score;
            PlayerPrefs.SetInt("highscore", TriggerController.score);
            highscoreText.text = "highscore - " + highscore.ToString("00");
        }

        if (Health < 0)
        {
            gameOverScreen.SetActive(true);
            Cursor.visible = true;
            anim.SetTrigger("isGameOver");          
            StartCoroutine(Stop());
        }
            
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        Time.timeScale = 1;
        animStart.SetTrigger("isGameStarted");
        AS.PlayOneShot(whoosh);
        Cursor.visible = false;
    }
}
