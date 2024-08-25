using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    public GameObject pipe;

    public int score;

    bool isGameover;
    UIManager ui;
    PlayerController pl;
    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        pl = FindObjectOfType<PlayerController>();
        ui.SetScoretext("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover)
        {
            ui.ShowGameOverPanel(true);
            ui.SetFinalScoreText("Your Score: " + score);
            return;

        }
    }
    public void RePlay(int index)
    {
        score = 0;
        isGameover = false;
        ui.SetScoretext("Score: " + score);

        ui.ShowGameOverPanel(false);
        SceneManager.LoadScene("airplane");
    }

    public void RePlay2(int index)
    {
        score = 0;
        isGameover = false;
        ui.SetScoretext("Score: " + score);

        ui.ShowGameOverPanel(false);
        SceneManager.LoadScene("airplane2");
    }


    public void Back(int index)
    {

        SceneManager.LoadScene("Menu");
    }

    public void Normal(int index)
    {

        SceneManager.LoadScene("airplane");
    }

    public void Hard(int index)
    {

        SceneManager.LoadScene("airplane2");
    }

    public void level(int index)
    {

        SceneManager.LoadScene("level");
    }
    public void infor(int index)
    {

        SceneManager.LoadScene("infor");
    }


    public void SetScore(int value)
    {
        score = value;
    }
    public int GetScore()
    {
        return score;
    }

    public void IncrementScore()
    {
        score = score + 1* ScoreMultiplier.Ins.xScore;
        ui.SetScoretext("Score: " + score);
    }

    public bool IsGameover()
    {
        return isGameover;
    }
    public void SetGameoverState(bool state)
    {
        isGameover = state;
    }

}
