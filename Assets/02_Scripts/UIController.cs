using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI text_score;

    public GameObject gameOverUIGroup;

    public TextMeshProUGUI text_bestScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreTextUI(int _score)
    {
        text_score.text = $"점수 : {_score.ToString()}";
    }

    public void SetGameOverUIGroupActive(bool _active)
    {
        gameOverUIGroup.SetActive( _active);
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateBestScoreText(int _score)
    {
        text_bestScore.text = $"최고 점수 : {_score.ToString()}";
    }
}