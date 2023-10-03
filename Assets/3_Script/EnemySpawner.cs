using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;    // 적 생성을 위한 스테이지 크기 정보
    [SerializeField]
    private GameObject[] enemyPrefab; // 복제해서 생성할 적 캐릭터 프리팹
    [SerializeField]
    private float spawnTime;        // 생성 주기
    

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

     private IEnumerator SpawnEnemy()
     {
        while (true)
        {
            // y 위치는 스테이지의 크기 범위 내에서 임의의 값을 선택
            float positionY = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
            // 적 캐릭터 생성
            //for(int i=0; i<enemyPrefab.Length; i++)
            //{
            //    Instantiate(enemyPrefab[i], new Vector3(stageData.LimitMax.x + 1.0f, positionY, 0.0f), Quaternion.identity);
            //}
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], new Vector3(stageData.LimitMax.x + 1.0f, positionY, 0.0f), Quaternion.identity);
            // spawnTime 만큼 대기
            yield return new WaitForSeconds(spawnTime);
        }


      }
        

}
