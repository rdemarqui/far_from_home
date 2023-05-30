using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text textScore;
    public PlayerController player;
    Vector3 initialPosition, finalPosition;
    public int scoreDivider;
    public GameObject panelGameOver, panelWin;
    public AudioClip sfxWinGame;
    public AudioController audioController;
    public AnimationArrival animationArrival;
    private float score;

    void Start()
    {
        initialPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if(!panelWin.activeSelf)
        {
            Vector3 treveledDistance = player.transform.position - initialPosition;
            float score = treveledDistance.z / scoreDivider;
            textScore.text = score.ToString("0");
        }
        else
        {
            Vector3 treveledDistance = finalPosition - initialPosition;
            float score = treveledDistance.z / scoreDivider;
            textScore.text = score.ToString("0");
        }
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);      
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void WinGame()
    {
        finalPosition = player.transform.position;
        audioController.audioSourceBackgroundMusic.Pause();
        audioController.PlaySFX(sfxWinGame);
        panelWin.SetActive(true);
        animationArrival.TakeShipToPlanet();
    }

}