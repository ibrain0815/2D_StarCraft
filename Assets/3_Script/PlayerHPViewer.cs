using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    
    private  PlayerHP playerHP; //플레이어의 데미지 정보에 접근하기 위해
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
            //플레이어가 나오고 찾으려면 여기에서 찾아야함
            playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("플레이어가 없습니다.");
        }



        
        
        // Slider UI에 현재 체력 정보를 업데이트
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;

    }
}
