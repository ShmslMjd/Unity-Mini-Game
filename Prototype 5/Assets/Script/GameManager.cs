using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //import TMPRo package so that we can interact with the score
using UnityEngine.SceneManagement; //to interact and manage scene in the folder
using UnityEngine.UI; //to interact with the button

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    private int score; //variable to store score
    private float spawnRate = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate); //control the length of time between each spawn
            int index = Random.Range(0, targets.Count); //target.Count count number of object in the list in this case its 4
            Instantiate(targets[index]);

        }
    }

    public void UpdateScore (int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score: " + score; //link with score so the score will update later
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //load the starting scene
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        //set the variable first before the function
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0); //display score 0 at start

        titleScreen.gameObject.SetActive(false);
    }
}
