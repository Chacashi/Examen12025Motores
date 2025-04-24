using Unity.VisualScripting;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
  [SerializeField] private  PlayerController[] arrayPlayers;


    [Header("State Game")]
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private CanvasGroup panelWin;


    private void Start()
    {
        arrayPlayers[0].enabled = true;
    }



    void ChanguePlayer()
    {
        
    }

    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += PlayerLose;
        PlayerController.OnPlayerTakeTrush += PlayerWin;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= PlayerLose;
        PlayerController.OnPlayerTakeTrush -= PlayerWin;
    }
    void PlayerLose()
    {

        Time.timeScale = 0.0f;
        panelLose.alpha = 1.0f;
        panelLose.interactable = true;
        panelLose.blocksRaycasts = true;

    }

    void PlayerWin()
    {
        Time.timeScale = 0.0f;
        panelWin.alpha = 1.0f;
        panelWin.interactable = true;
        panelWin.blocksRaycasts = true;
    }



}
