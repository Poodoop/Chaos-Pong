using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int scoreToReach;

    private int playerScore = 0;
    private int playerAIScore = 0;
    private int levelLoad;
    
    public Text playerScoreText;
    public Text playerAIScoreText;


    int validChoices[] = [1,3,5];

    public void PlayerGoal()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString(); 
        CheckScore();
    }

    public void PlayerAIGoal()
    {
        playerAIScore++;
        playerAIScoreText.text = playerAIScore.ToString();  
        CheckScore();
    }

    private int GetRandom()
    {
        return validChoices[Random.Range(0, validChoices.Length)];
    }

private void CheckScore()
    {
        if(playerScore == scoreToReach || playerAIScore == scoreToReach)
        {
            levelLoad = GetRandom();
            SceneManager.LoadScene(levelLoad);
            
        }

    }
}