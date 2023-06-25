using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There is more than one GameManager object active in the scene!");
            Destroy(gameObject);
        }
        Instance = this;
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

}
