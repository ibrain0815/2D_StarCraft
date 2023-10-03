using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;    // �� ������ ���� �������� ũ�� ����
    [SerializeField]
    private GameObject[] enemyPrefab; // �����ؼ� ������ �� ĳ���� ������
    [SerializeField]
    private float spawnTime;        // ���� �ֱ�
    

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

     private IEnumerator SpawnEnemy()
     {
        while (true)
        {
            // y ��ġ�� ���������� ũ�� ���� ������ ������ ���� ����
            float positionY = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
            // �� ĳ���� ����
            //for(int i=0; i<enemyPrefab.Length; i++)
            //{
            //    Instantiate(enemyPrefab[i], new Vector3(stageData.LimitMax.x + 1.0f, positionY, 0.0f), Quaternion.identity);
            //}
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], new Vector3(stageData.LimitMax.x + 1.0f, positionY, 0.0f), Quaternion.identity);
            // spawnTime ��ŭ ���
            yield return new WaitForSeconds(spawnTime);
        }


      }
        

}
