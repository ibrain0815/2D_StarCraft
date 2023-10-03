using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; //적 공격력
    [SerializeField]
    private int scorePoint = 100;  // 적 처치시 획득 점수
    private PlayerControll playerController; // 플레이어의 점수(score) 정보에 접근하기 위해

    [SerializeField]
    private GameObject[] itemPrefabs;   // 적을 죽였을 때 획득 가능한 아이템


    private void Awake()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 "Player"이면 
        if (collision.CompareTag("Player"))
        {

            //폭발 효과
            Instantiate(GameManager.Instance.explosionPrefab, transform.position, Quaternion.identity);
            //폭발 소리
            GameManager.Instance.boomSFX.Play();

            // 적 공격력만클 플레이어 체력 감소
            collision.GetComponent<PlayerHP>().TakeDamage(damage);

            //적 사망시 호출하는 함수
            OnDie();
            

        }
    }

    public void OnDie()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        //플레이어의 점수를  scorePoint만큼 증가시킨다.
        playerController.Score += scorePoint;
        // 일정 확률로 아이템 생성
        SpawnItem();
        
        // 적 오브젝트 삭제
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
