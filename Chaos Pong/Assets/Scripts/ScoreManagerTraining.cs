using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerTraining : MonoBehaviour
{
    public int scoreToReach = 5;

    private int playerScore = 0;
    private int playerAIScore = 0;
    private int levelLoad;

    public Text playerScoreText;
    public Text playerAIScoreText;

    public AIControlAgent agent;

    public void PlayerGoal()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
        agent.AddReward(-5f);
        agent.EndEpisode();
        CheckScore();
    }

    public void PlayerAIGoal()
    {
        playerAIScore++;
        playerAIScoreText.text = playerAIScore.ToString();
        agent.EndEpisode();
        CheckScore();
    }

    private void CheckScore()
    {
        if (scoreToReach <= 0)
        {
            Debug.LogError("Score to reach is not positive");
            return;
        }

        if (playerScore == scoreToReach || playerAIScore == scoreToReach)
        { 
                agent.EndEpisode();            
        }
    }
}