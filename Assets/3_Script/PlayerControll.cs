using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControll : MonoBehaviour
{
    
    public float speed;

    [SerializeField]
    private string nextSceneName;

    [SerializeField]
    private StageData stageData;

    [SerializeField]
    private float attackRate = 3f;  //공격 속도

    private int attackLevel = 1; //공격 레벨
    [SerializeField]
    private int maxAttackLevel = 3; //공격 최대 레벨

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }


    public KeyCode keyCodeAttack = KeyCode.Space;

    private int score;
    public int Score
    {
        // score 값이 음수가 되지 않도록
        set => score = Mathf.Max(0, value);
        get => score;
    }


    // Start is called before the first frame update
    void Start()
    {
        

    }



    // Update is called once per frame
    public void Update()
    {
        Vector3 vec = new Vector3(GameManager.Instance.variableJoystick.Horizontal,
                          GameManager.Instance.variableJoystick.Vertical, 0);
        transform.Translate(vec * speed * Time.deltaTime);


        // 공격 키를 Down/Up으로 공격 시작/종료
        if (Input.GetKeyDown(keyCodeAttack))
        {
            StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            StopFiring();
        }


    }


    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }
    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }
    private IEnumerator TryAttack()
    {
        while (true)
        {

            //발사체 오브젝트 생성
            //Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
            // 공격 레벨에 따라 발사체 생성
            AttackByLevel();
            
            //레이져 발사 소리
            GameManager.Instance.laserSFX.Play(); 

            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);

        }
    }


    private void LateUpdate()
    {
        //플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하도록 함.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    public void Ondie()
    {
        // 디바이스에 획득한 점수 score 저장
        PlayerPrefs.SetInt("Score", score);

        //플레이어 사망시 nextSceneName 씬으로 이동
        SceneManager.LoadScene(nextSceneName);
    }
    
    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;
        switch (attackLevel)
        {
            case 1:// Level 01 :  기존과 같이 발사체 1개 생성
                Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                break;
            case 2: // Level 02 : 간격을 두고 전방으로 발사체 2개 생성
                Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0) + Vector3.up * 1f, Quaternion.identity);
                Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0) + Vector3.down * 1f, Quaternion.identity);
                break;
            case 3: // Level 03 : 전방으로 발사체 1개, 좌우 대각선 방향으로 발사체 각 1개
                Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                // 왼쪽 대각선 방향으로 발사되는 발사체
                cloneProjectile = Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(1, -0.2f, 0));
                // 오른쪽 대각선 방향으로 발사되는 발사체
                cloneProjectile = Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(1, 0.2f, 0));
                break;

        }
    }

}
