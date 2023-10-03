using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float rotationLimit = 40;
    [SerializeField] private float rotationSpeed = 15;
    private PlayerControll playerControll;
    public bool rotate = false;

    void FixedUpdate()
    {
        float targetRotate = rotate ? rotationLimit : 0f;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(targetRotate, 0, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
    }

    private void Update()
    {
        try
        {
            //플레이어가 나오고 찾으려면 여기에서 찾아야함
            playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
            
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("플레이어가 없습니다.");
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        rotate = true;
        playerControll.StartFiring(); //미사일 발사
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        rotate = false;
        playerControll.StopFiring(); //미사일 정지
    }
}
