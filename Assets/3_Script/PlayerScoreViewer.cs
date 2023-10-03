using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreViewer : MonoBehaviour
{

    private PlayerControll playerController; // 플레이어의 점수(score) 정보에 접근하기 위해
    private TextMeshProUGUI textScore;

    // Start is called before the first frame update
    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();

    }


    // Update is called once per frame
    void Update()
    {
        try
        {
            //플레이어가 나오고 찾으려면 여기에서 찾아야함
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("플레이어가 없습니다.");
        }


        //Text UI에 현재 점수 정보를 업데이트
        textScore.text = "Score : " + playerController.Score;
    }
}
