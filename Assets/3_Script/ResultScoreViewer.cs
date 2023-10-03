
using UnityEngine;
using TMPro;

public class ResultScoreViewer : MonoBehaviour
{
    private TextMeshProUGUI textResultScore;

    private void Awake()
    {
        textResultScore = GetComponent<TextMeshProUGUI>();
        // Stage 에서 저장한 점수를 불러와서 score변수에 저장
        int score = PlayerPrefs.GetInt("Score");
        // textResultScore UI에 점수 갱신
        textResultScore.text = "Result Score " + score;
    }
}
