using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score    //프로퍼티 Property : 데이터를 은닉, 변경되는걸 제한
    {
        get
        {
            return score;
        }

        private set
        {
            if (value < 0) return;  //점수에 -1점을 넣으려고 하면 막아버림
            score = value;
        }
    }
    private int score;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Score = 0;  //게임시작시, 점수 초기화
    }

    void Update()
    {
        
    }

    // 점수를 1점 증가하는 함수 (주로 적군 죽이고 점수 증가시키는 용도)
    public void AddScore()
    {
        Score++;
    }
}
