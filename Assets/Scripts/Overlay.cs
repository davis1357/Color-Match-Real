using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Overlay : MonoBehaviour
{
    [SerializeField] Text pointsText;
    [SerializeField] Text livesText;
    private float score = 0f;
    private float lives = 3f;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaiseScore()
    {
        score++;
        pointsText.text = "Score: " + score.ToString();
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0f)
        {
            SceneManager.LoadScene(0);
            //TODO: high score.
        }
    }
}
