using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private int damage = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�߻�ü�� �ε��� ������Ʈ�� �±װ� "Enemy"�̸�
        if (collision.CompareTag("Enemy"))
        {
            
            //���� ȿ��
            Instantiate(GameManager.Instance.explosionPrefab, transform.position, Quaternion.identity);
            //���� �Ҹ�
            GameManager.Instance.boomSFX.Play();

            //�ε��� ������Ʈ ��� ó��(��)
            // collision.GetComponent<Enemy>().OnDie();
            collision.GetComponent<EnemyHP>().TakeDamege(damage);
            //�� ������Ʈ ����(�߻�ü!)
            Destroy(gameObject);
        }
    }



}
