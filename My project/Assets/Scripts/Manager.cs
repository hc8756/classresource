using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int lives;
    public GameObject gameOverScreen;
    public TMP_Text gameOverText;
    public TMP_Text livesText;

    // Start is called before the first frame update
    void Awake()
    {
        lives = 3;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives left:" + lives;
        if (lives <= 0) {
            gameOver(false);
        }
    }

    public void gameOver(bool won) {
        if (won) { gameOverText.text = "You Won!"; }
        else { gameOverText.text = "You Died!"; }
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void restart() {
        SceneManager.LoadScene(0);
    }
}
