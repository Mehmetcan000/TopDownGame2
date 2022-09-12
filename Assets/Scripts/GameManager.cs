using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
   
    [SerializeField]
    GameObject missionFailed;
    [SerializeField]
    GameObject missionComplete;
    [SerializeField]
    CountDownTimer timer;
    [SerializeField]
    GameObject player;
    

    public static GameManager instance;

    public int scoreMultiple;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void MissionComplete()
    {
        missionComplete.SetActive(true);
        UIManager.instance.ScoreCalculation(scoreMultiple * timer.currentTime);
       //  missionComplete.GetComponent<CanvasGroup>().DOFade(1, .5f);
      //   missionComplete.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }
    public void MissionFailed()
    {
        missionFailed.SetActive(true);
        Destroy(player);
      
           // missionFailed.GetComponent<CanvasGroup>().DOFade(1, .5f);
           // missionFailed.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }
  


  
    public void RestartGame()
    {
        SceneManager.LoadScene(LevelData.GetCurrentLevelName(LevelData.currentLevel));
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TurnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        if (LevelData.currentLevel < LevelData.maxLevel)
        {
            LevelData.currentLevel = LevelData.currentLevel + 1;
            SceneManager.LoadScene(LevelData.GetCurrentLevelName(LevelData.currentLevel));
        }
        else
        {
            TurnBack();
        }

    }

}
