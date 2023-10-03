using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;  // �ִ� ü��
    private float currentHP;   // ���� ü��
    private SpriteRenderer spriteRenderer;
    private PlayerControll playerController;
    public float MaxHP => maxHP; //maxHP ������ ������ �� �ִ� ������Ƽ (Get�� ����)
    public float CurrentHP   //  currentHP ������ ������ �� �ִ� ������Ƽ (Set,Get����)
    {
        set => currentHP = Mathf.Clamp(value, 0, maxHP);
        get => currentHP;
    }

    private void Awake()
    {
        currentHP = maxHP;   //  ���� ü���� �ִ� ü�°� ���� ����
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerController = GetComponent<PlayerControll>();
    }


    public void TakeDamage(float damage)
    {
        //���� ü����  damage��ŭ ����
        currentHP -= damage;
        
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü���� 0���� = �÷��̾� ĳ���� ���
        if(currentHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Player HP : 0.. Die" );
            
        }
        // ü���� 0�̸� onDie() �Լ��� ȣ���ؼ� �׾��� �� ó���� �Ѵ�
        if(currentHP <= 0)
        {
            playerController.Ondie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // �÷��̾��� ������ ����������
        spriteRenderer.color = Color.red;

        // 0.1�� ���� ���
        yield return new WaitForSeconds(0.1f);
        // �÷��̾��� ������ ���� ������ �Ͼ������ 
        // (���� ������ �Ͼ���� �ƴ� ��� ���� ���� ���� ����)
        spriteRenderer.color = Color.white;
    }

}
