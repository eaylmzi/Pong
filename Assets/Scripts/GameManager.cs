using Assets.Scripts.Constants;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CountdownManager countdownManager;
    public Ball ball;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI computerScoreText;

    public Paddle playerPaddle;
    public Paddle computerPaddle;

    private int _playerScore;
    private int _computerScore;


    private void Start()
    {      
        InitializeGame();
    }

    private void InitializeGame()
    {
        ball.ResetPosition();
        countdownManager.InitiateCountdown();
    }
    public void IncreasePlayerScore()
    {
        _playerScore += 1;
        this.playerScoreText.text = _playerScore.ToString();
        ResetRound();
    }
    public void IncreaseComputerScore()
    {
        _computerScore += 1;
        this.computerScoreText.text = _computerScore.ToString();
        ResetRound();
    }

    public void PlayWallSong()
    {
        AudioManager.instance.Play(SoundName.HIT_WALL);
    }
    private void ResetRound()
    {
        AudioManager.instance.Play(SoundName.SCORE);

        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();

        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }
}
