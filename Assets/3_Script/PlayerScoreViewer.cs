using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreViewer : MonoBehaviour
{

    private PlayerControll playerController; // �÷��̾��� ����(score) ������ �����ϱ� ����
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
            //�÷��̾ ������ ã������ ���⿡�� ã�ƾ���
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("�÷��̾ �����ϴ�.");
        }


        //Text UI�� ���� ���� ������ ������Ʈ
        textScore.text = "Score : " + playerController.Score;
    }
}
