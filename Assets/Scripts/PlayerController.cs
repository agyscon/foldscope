using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int position = 0;


    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float deceleration;
    [SerializeField]
    private float targetVelocity;
    [SerializeField]
    private float prevVelocity;
    [SerializeField]
    private float shiftLaneDelta;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    /// <summary>
    /// Following calculate movement for the car in the game
    /// </summary>
    private void Movement()
    {
        float a_term = 0;
        float v_term = 0;

        float totalVelocity = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            a_term = acceleration * Time.deltaTime;
            v_term = prevVelocity;

            totalVelocity = Mathf.Clamp(a_term + v_term, 0f, targetVelocity);

            float deltaDistance = totalVelocity * Time.deltaTime;

            transform.Translate(Vector3.forward * deltaDistance);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            a_term = -deceleration * Time.deltaTime;
            v_term = prevVelocity;

            totalVelocity = a_term + v_term;

            float deltaDistance = Mathf.Clamp(totalVelocity * Time.deltaTime, 0f, int.MaxValue);

            transform.Translate(Vector3.forward * deltaDistance);
        }
        else
        {
            totalVelocity = prevVelocity;

            float deltaDistance = Mathf.Clamp(totalVelocity * Time.deltaTime, 0f, int.MaxValue);

            transform.Translate(Vector3.forward * deltaDistance);
        }


        // position = 0 means middle lane
        // position = -1 means left lane
        // positin = 1 means right lane
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (position > -1)
            {
                transform.Translate(Vector3.left * shiftLaneDelta);
                Camera.main.transform.Translate(Vector3.right * shiftLaneDelta);
                position--;
            }
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (position < 1)
            {
                transform.Translate(Vector3.right * shiftLaneDelta);
                Camera.main.transform.Translate(Vector3.left * shiftLaneDelta);
                position++;
            }

        }


        if (prevVelocity == 0)
        {
            prevVelocity = a_term;
        }
        else
        {
            prevVelocity = totalVelocity;
        }

        //Debug.Log($"accel velocity is: {a_term},  prev velocity is: {prevVelocity}");
    }


    public void TriggerObstacle()
    {
        prevVelocity = 0f;
    }
}
