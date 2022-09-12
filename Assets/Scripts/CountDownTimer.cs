using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDownTimer : MonoBehaviour
{
    [SerializeField]
    private  Image timerImg;
    [SerializeField]
    private Text timerText;
    public float currentTime;
    public float duration;
  
    void Start()
    {
        currentTime = duration;
        timerText.text = currentTime.ToString();
        StartCoroutine(UpdateTime());
        
    }
    IEnumerator UpdateTime()
    {
        yield return null;
        while (currentTime>=0)
        {
            timerImg.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;

        }
        if (currentTime<=0)
        {
            timerText.text = "Süre Doldu";
            GameManager.instance.MissionFailed();
        }

    }
  

}
