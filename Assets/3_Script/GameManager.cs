using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // �̱��� : ��� �Լ��� ���� ���
    public PlayerSpawner playerSpawner;
    public VariableJoystick variableJoystick;
    public AudioSource boomSFX;
    public AudioSource laserSFX;
    public GameObject explosionPrefab;
    public GameObject weaponPrefab;
    public ShootButton shootButton;
   // public int selectPlayer = 0; //�÷��̾� ����(0:�׶�,1:����,2:�����佺)

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        playerSpawner.SpawnPlayer(PlayerPrefs.GetInt("Kind")); // �÷��̾� ����
    }


}
