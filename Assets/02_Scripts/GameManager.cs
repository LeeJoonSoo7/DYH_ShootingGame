using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController uiController;

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
        uiController.UpdateScoreTextUI(Score);
    }

    // 플레이어가 죽었을 때의 호출하는 함수
    public void OnPlayerDeath()
    {
        uiController.SetGameOverUIGroupActive(true);

        // 최고 점수 갱신
        int _bestScore = 0;
        string _key = "BEST_SCORE";
        if (PlayerPrefs.HasKey(_key))
        {
            _bestScore = PlayerPrefs.GetInt(_key);
        }

        if (_bestScore < this.Score)
        {
            PlayerPrefs.SetInt(_key, this.Score);
            _bestScore = this.Score;
        }

        uiController.UpdateBestScoreText(_bestScore);
    }
}
