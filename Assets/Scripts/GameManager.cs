using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 0.1f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI onemoreText;
    public Button retry;

    private GameObject plane;
    private GameObject missileSpawner;

    private float score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    void Start()
    {
        plane = GameObject.Find("Plane");
        missileSpawner = GameObject.Find("MissileSpawner");
        NewGame();   
    }
    public void NewGame()
    {


        gameSpeed = initialGameSpeed;
        score = 0f;
        enabled = true;

        plane.SetActive(true);
        //missileSpawner.SetActive(true);
        onemoreText.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);

        
        UpdateHiscore();
    }
    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;
        plane.SetActive(false);
        //missileSpawner.SetActive(false);
        onemoreText.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);

        UpdateHiscore();
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;

        score += gameSpeed *3f * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }
}


