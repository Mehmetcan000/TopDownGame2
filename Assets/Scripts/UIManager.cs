using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text currentAmmoText;
    [SerializeField]
    private Text maxAmmoText;
    [SerializeField]
    private Text reloadText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject informationText;
    [SerializeField]
    private Text currentLeveltext;




    public static UIManager instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        informationText.SetActive(true);
        Invoke("InformationText", 5f);
    }

    public void ScoreCalculation(float score)
    {
        scoreText.text = score.ToString();
    }
    public void InformationText()
    {
        informationText.SetActive(false);
    }

    public void CurrentLevelText(int currentLevel)
    {
        currentLeveltext.text = currentLevel.ToString();
    }
  
    public void SetGunCurrentText(int currentAmmo)
    {
        currentAmmoText.text = currentAmmo.ToString();
    }
    public void SetGunMaxAmmo(int maxAmmo)
    {
        maxAmmoText.text = maxAmmo.ToString();  
    }

    public void ReloadingText(bool isReloading)
    {
        reloadText.gameObject.SetActive(isReloading);
    }



}
