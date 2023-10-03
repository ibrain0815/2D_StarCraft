using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField]
    private Transform target; //���� ���ӿ����� �ΰ��� ����� ���ΰ� ������ Ÿ��
    [SerializeField]
    private float scrollRange = 75f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.right;


    // Update is called once per frame
    void Update()
    {
        //����� moveDirection�������� moveSpeed �� �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //����� ������ ������ ����� ��ġ �缳��
        if(transform.position.x <= -scrollRange)
        {
            transform.position = target.position + Vector3.right * scrollRange;
        }
    }
}
