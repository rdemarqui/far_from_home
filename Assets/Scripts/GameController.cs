using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text textScore;
    public PlayerController player;
    Vector3 initialPosition;
    public int scoreDivider;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 treveledDistance = player.transform.position - initialPosition;
        float score = treveledDistance.z / scoreDivider;
        textScore.text = score.ToString("0");
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
