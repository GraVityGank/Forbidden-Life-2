using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int scoreValue = 0;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "" + scoreValue;
    }
}
