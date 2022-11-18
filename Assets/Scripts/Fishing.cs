using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{

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
    [SerializeField] float hookSize = 0.18f;
    [SerializeField] float hookSpeed = 0.10f;
    [SerializeField] float hookGravity = 0.05f;
    float hookPos, hookPullVelocity;

    private void FixedUpdate()
    {
        MoveFish();
        MoveHook();
    }

    private void MoveFish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0)
        {
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPos = Random.value; //[0f, 1f]
        }
        fishPos = Mathf.SmoothDamp(fishPos, fishTargetPos, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottumBounds.position, topBounds.position, fishPos);
    }

    private void MoveHook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookSpeed * Time.deltaTime;
        }
        hookPullVelocity -= hookGravity * Time.deltaTime;

        hookPos += hookPullVelocity;
        hookPos = Mathf.Clamp(hookPos, 0, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
