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
    private float attackRate = 3f;  //���� �ӵ�

    private int attackLevel = 1; //���� ����
    [SerializeField]
    private int maxAttackLevel = 3; //���� �ִ� ����

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }


    public KeyCode keyCodeAttack = KeyCode.Space;

    private int score;
    public int Score
    {
        // score ���� ������ ���� �ʵ���
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


        // ���� Ű�� Down/Up���� ���� ����/����
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

            //�߻�ü ������Ʈ ����
            //Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
            // ���� ������ ���� �߻�ü ����
            AttackByLevel();
            
            //������ �߻� �Ҹ�
            GameManager.Instance.laserSFX.Play(); 

            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);

        }
    }


    private void LateUpdate()
    {
        //�÷��̾� ĳ���Ͱ� ȭ�� ���� �ٱ����� ������ ���ϵ��� ��.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    public void Ondie()
    {
        // ����̽��� ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);

        //�÷��̾� ����� nextSceneName ������ �̵�
        SceneManager.LoadScene(nextSceneName);
    }
    
    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;
        switch (attackLevel)
        {
            case 1:// Level 01 :  ������ ���� �߻�ü 1�� ����
                Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                break;
            case 2: // Level 02 : ������ �ΰ� �������� �߻�ü 2�� ����
                Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0) + Vector3.up * 1f, Quaternion.identity);
                Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0) + Vector3.down * 1f, Quaternion.identity);
                break;
            case 3: // Level 03 : �������� �߻�ü 1��, �¿� �밢�� �������� �߻�ü �� 1��
                Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                // ���� �밢�� �������� �߻�Ǵ� �߻�ü
                cloneProjectile = Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(1, -0.2f, 0));
                // ������ �밢�� �������� �߻�Ǵ� �߻�ü
                cloneProjectile = Instantiate(GameManager.Instance.weaponPrefab, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(1, 0.2f, 0));
                break;

        }
    }

}
