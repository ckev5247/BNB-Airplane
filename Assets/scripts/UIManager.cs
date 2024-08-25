using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoretext;
    public TMP_Text FinalScoreText;
    public GameObject gameoverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoretext(string txt)
    {
        if (scoretext)
            scoretext.text = txt;
    }

    public void ShowGameOverPanel(bool isShow)
    {
        if (gameoverPanel)

            gameoverPanel.SetActive(isShow);

    }

    public void SetFinalScoreText(string txt)
    {
        if (FinalScoreText)
            FinalScoreText.text = txt;
        //  ui.SetScoreText("Score: " + score);
    }
}
