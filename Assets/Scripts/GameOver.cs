using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private EnemyGenerator enemyGenerator;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private Score score;
    public void EndGame()
    {
        enemyGenerator.enabled = false;
        int finalScore = score.stopScoring();
        gameOverText.text =$"Your Score: {finalScore}"; 
        gameOverDisplay.gameObject.SetActive(true);
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {
        AdManager.Instance.ShowAd(this);
        continueButton.interactable = false;
    }
    public void ContinueGame()
    {
        score.startTimer();
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemyGenerator.enabled = true;
        gameOverDisplay.gameObject.SetActive(false);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
