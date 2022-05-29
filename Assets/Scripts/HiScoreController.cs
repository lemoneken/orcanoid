using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiScoreController : MonoBehaviour
{
    private TextMeshProUGUI textField;
    public int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHiScore(int points)
    {
        totalScore += points;
        textField.text = totalScore.ToString();
    }
}
