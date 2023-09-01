using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    [SerializeField]
    float distanceGoal = 10f;

    [SerializeField]
    float timeRemaining = 20f;

    [SerializeField]
    TMP_Text distanceText;

    [SerializeField]
    TMP_Text timeLeftText;

    [SerializeField]
    GameObject youWon;

    [SerializeField]
    GameObject youLost;

    float internalTimer;
    // Start is called before the first frame update
    void Start()
    {
        internalTimer = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }

        float distanceRemaining = distanceGoal - player.transform.position.z;

        

        if (player.transform.position.z > distanceGoal)
        {
            youWon.SetActive(true);
        }

        if (internalTimer <= 0)
        {
            youLost.SetActive(true);
            Debug.Log("Game over");
        } else
        {
            internalTimer -= Time.deltaTime;
        }

        Debug.Log($"Distance remaining is {distanceRemaining}, Time remaining is {internalTimer}");

        if (distanceText != null)
        {
            distanceText.text = "Distance Left: " + distanceRemaining.ToString("00");
        }

        if (timeLeftText != null)
        {
            TimeSpan time = TimeSpan.FromSeconds(internalTimer);

            timeLeftText.text = "Time Left: " + time.ToString("mm':'ss");
        }
    }
}
