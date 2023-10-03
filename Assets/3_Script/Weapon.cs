using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private int damage = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //발사체에 부딪힌 오브젝트의 태그가 "Enemy"이면
        if (collision.CompareTag("Enemy"))
        {
            
            //폭발 효과
            Instantiate(GameManager.Instance.explosionPrefab, transform.position, Quaternion.identity);
            //폭발 소리
            GameManager.Instance.boomSFX.Play();

            //부딪힌 오브젝트 사망 처리(적)
            // collision.GetComponent<Enemy>().OnDie();
            collision.GetComponent<EnemyHP>().TakeDamege(damage);
            //내 오브젝트 삭제(발사체!)
            Destroy(gameObject);
        }
    }



}
