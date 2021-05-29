using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;


    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}