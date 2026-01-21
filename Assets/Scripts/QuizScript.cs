using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 

[System.Serializable]
public class Question
{
    public string questionText;
    public bool isTrue; // If true, "Yes" is correct. If false, "No" is correct.
}

public class QuizScript : MonoBehaviour
{
    public List<Question> questions; 
    public TextMeshProUGUI questionDisplayText;
    public GameObject quizPanel;
    public GameObject resultPanel;

    private int currentQuestionIndex = 0;
    private int score = 0;

    //used to switch scene
    private bool isQuizFinished = false;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            questionDisplayText.text = questions[currentQuestionIndex].questionText;
        }
        else
        {
            EndQuiz();
        }
    }

    public void UserSelect(bool selection)
    {
        if (selection == questions[currentQuestionIndex].isTrue)
        {
            score++;
            Debug.Log("Correct!");
        }
        else {
            Debug.Log("Inorrect!");
        }

            currentQuestionIndex++;
        DisplayQuestion();
    }

    void Update()
    {
        // Only check for these keys if the quiz is actually over
        if (isQuizFinished)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RestartGame();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                SwitchScene();
            }
        }
    }

    void EndQuiz()
    {
        isQuizFinished = true; // Enable the key listener
        quizPanel.SetActive(false);
        resultPanel.SetActive(true);

        string diagnostic = (score >= 4) ?
            "High risk of Cardiovascular Disease. Need medicamentation." :
            "Symptoms appear mild.";

        if (resultPanel != null)
        {
            TextMeshProUGUI resultTextComp = resultPanel.GetComponent<TextMeshProUGUI>();
            // Added the instructions to the UI text
            resultTextComp.text = "Score: " + score + " / " + questions.Count + "\n" + diagnostic +
                                  "\n\nPress [E] to Restart\nPress [F] to Switch Scene";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("Demo");
    }
}
