using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    
    private  PlayerHP playerHP; //�÷��̾��� ������ ������ �����ϱ� ����
    private Slider sliderHP;
    

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
      
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            //�÷��̾ ������ ã������ ���⿡�� ã�ƾ���
            playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("�÷��̾ �����ϴ�.");
        }



        
        
        // Slider UI�� ���� ü�� ������ ������Ʈ
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;

    }
}
