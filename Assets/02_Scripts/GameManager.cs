using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController uiController;

    public int Score    //������Ƽ Property : �����͸� ����, ����Ǵ°� ����
    {
        get
        {
            return score;
        }

        private set
        {
            if (value < 0) return;  //������ -1���� �������� �ϸ� ���ƹ���
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
        Score = 0;  //���ӽ��۽�, ���� �ʱ�ȭ
    }

    void Update()
    {
        
    }

    // ������ 1�� �����ϴ� �Լ� (�ַ� ���� ���̰� ���� ������Ű�� �뵵)
    public void AddScore()
    {
        Score++;
        uiController.UpdateScoreTextUI(Score);
    }

    // �÷��̾ �׾��� ���� ȣ���ϴ� �Լ�
    public void OnPlayerDeath()
    {
        uiController.SetGameOverUIGroupActive(true);

        // �ְ� ���� ����
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
