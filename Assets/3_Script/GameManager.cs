using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // 싱글톤 : 모든 함수에 전역 사용
    public PlayerSpawner playerSpawner;
    public VariableJoystick variableJoystick;
    public AudioSource boomSFX;
    public AudioSource laserSFX;
    public GameObject explosionPrefab;
    public GameObject weaponPrefab;
    public ShootButton shootButton;
   // public int selectPlayer = 0; //플레이어 선택(0:테란,1:저그,2:프로토스)

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        playerSpawner.SpawnPlayer(PlayerPrefs.GetInt("Kind")); // 플레이어 생성
    }


}
