using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing : MonoBehaviour
{

    int lives;

    [Header("Fishing Area")]
    [SerializeField] Transform topBounds;
    [SerializeField] Transform bottumBounds;

    [Header("Fish Settings")]
    [SerializeField] Transform fish;
    [SerializeField] float smoothMotion = 3f;
    [SerializeField] float fishTimeRandomizer = 3f;
    float fishPos, fishSpeed, fishTimer, fishTargetPos;

    [Header("Hook Settings")]
    [SerializeField] Transform hook;
    [SerializeField] float hookSize = 0.20f;
    [SerializeField] float hookAcc = 0.10f;
    [SerializeField] float g = 0.80f;     //gravity acceleration constant
    float hookPos, hookPullVelocity;

    [Header("Progress Bar Settings")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] float hookPower;
    [SerializeField] float progressBarDecay;
    float catchProgress;

    float remainTime = 7.5f;

    private void FixedUpdate()
    {
        MoveFish();
        MoveHook();
        CheckProgress();
    }

    private void MoveFish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0)
        {
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPos = Random.value;
        }
        fishPos = Mathf.SmoothDamp(fishPos, fishTargetPos, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottumBounds.position, topBounds.position, fishPos);
    }

    private void MoveHook()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            hookPullVelocity += hookAcc * Time.deltaTime;
        }
        hookPullVelocity -= g * Time.deltaTime;

        hookPos += hookPullVelocity;

        if (   hookPullVelocity < 0 && hookPos <= hookSize/2
            || hookPullVelocity > 0 && hookPos >= 1 - hookSize/2)
        {
            hookPullVelocity = 0;
        }
        
        hookPos = Mathf.Clamp(hookPos, hookSize/2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottumBounds.position, topBounds.position, hookPos);
        
    }

    private void CheckProgress()
    {
        Vector3 progressBarScale = progressBarContainer.localScale;
        progressBarScale.y = catchProgress;
        progressBarContainer.localScale = progressBarScale;

        float min = hookPos - hookSize/2;
        float max = hookPos + hookSize/2;

        remainTime -= Time.deltaTime;

        if (min < fishPos && fishPos < max)
        {
            catchProgress += hookPower * Time.deltaTime;
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
            if (catchProgress <= 0) // LOSE if the bar reach the bottom
            {
                --lives;
                PlayerPrefs.SetInt("lives", lives);
                PlayerPrefs.SetInt("cat", 1);
                SceneManager.LoadScene("MainGame");
            }
        }

        if (remainTime <= 0) // WIN if player managed to keep the bar above 0 for a certain amount of time
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 5);
            PlayerPrefs.SetInt("cat", 2);
            SceneManager.LoadScene("MainGame");
        }
        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
