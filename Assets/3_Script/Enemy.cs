using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; //�� ���ݷ�
    [SerializeField]
    private int scorePoint = 100;  // �� óġ�� ȹ�� ����
    private PlayerControll playerController; // �÷��̾��� ����(score) ������ �����ϱ� ����

    [SerializeField]
    private GameObject[] itemPrefabs;   // ���� �׿��� �� ȹ�� ������ ������


    private void Awake()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "Player"�̸� 
        if (collision.CompareTag("Player"))
        {

            //���� ȿ��
            Instantiate(GameManager.Instance.explosionPrefab, transform.position, Quaternion.identity);
            //���� �Ҹ�
            GameManager.Instance.boomSFX.Play();

            // �� ���ݷ¸�Ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);

            //�� ����� ȣ���ϴ� �Լ�
            OnDie();
            

        }
    }

    public void OnDie()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        //�÷��̾��� ������  scorePoint��ŭ ������Ų��.
        playerController.Score += scorePoint;
        // ���� Ȯ���� ������ ����
        SpawnItem();
        
        // �� ������Ʈ ����
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if(spawnItem < 10)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if(spawnItem < 30)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
    }
}
