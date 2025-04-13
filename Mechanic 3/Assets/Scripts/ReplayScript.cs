using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayScript : MonoBehaviour
{

    [SerializeField]
    Transform playerTransform;

    Rigidbody2D rb;

    [SerializeField]
    //List<Transform> savedPlayerTransform = new List<Transform>();
    List<Vector2> savedPlayerPosition = new List<Vector2>();

    [SerializeField]
    float replayCap = 10;

    [SerializeField]
    float replayTimer = 0;

    public bool isReplaying;

    int currentReplayFrame;

    int replayFrameRate;

    float savedTime = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = transform;

        rb = GetComponent<Rigidbody2D>();

        isReplaying = false;
    }

    private void Update()
    {
        replayTimer += Time.deltaTime;

        //if (!isReplaying)
        //{
            //savedPlayerTransform.Add(playerTransform);
            //savedPlayerPosition.Add(playerTransform.position);
        //}

        if (isReplaying)
        {


            //Debug.Log(savedTime);

            if(replayTimer > savedTime + replayCap)
            {
                replayFrameRate = 0;
                isReplaying = false;
                rb.bodyType = RigidbodyType2D.Dynamic;

            }
        }

        //replayFrameRate = 0;
    }

    void FixedUpdate()
    {

        if (!isReplaying)
        {
            //savedPlayerTransform.Add(playerTransform);
            savedPlayerPosition.Add(playerTransform.position);
        }
        else
        {
            int nextFrame = currentReplayFrame -1;


            //if (nextFrame < savedPlayerTransform.Count && nextFrame >= 0) 
            if (nextFrame < savedPlayerPosition.Count && nextFrame >= 0) 
            {
                SetTransform(nextFrame);
            }
        }

        //Debug.Log(savedPlayerTransform[savedPlayerTransform.Count-1].position);
    }

    void SetTransform(int frame)
    {
        currentReplayFrame = frame;

        //Transform currentTransform = savedPlayerTransform[frame];
        Vector2 currentTransform = savedPlayerPosition[frame];
        //Debug.Log(currentTransform.position);
        Debug.Log(currentTransform);
        //playerTransform.position = currentTransform.position;
        playerTransform.position = currentTransform;

    }

    public void Replay()
    {
        if (replayTimer > replayCap)
        {
            isReplaying = true;

            rb.bodyType = RigidbodyType2D.Static;
            //SetTransform(savedPlayerTransform.Count - 1);
            SetTransform(savedPlayerPosition.Count - 1);

            replayFrameRate = -1;

            savedTime = replayTimer;

            //yield return new WaitForSecondsRealtime(replayCap);
        }
    }



    /*public void ReplayTest()
    {
        if (replayTimer > replayCap)
        {
            isReplaying = true;

            for (int i = savedPlayerTransform.Count - 1; i >= 0; i--)
            {
                Transform t = savedPlayerTransform[i];
                playerTransform.position = t.position;

                Debug.Log(i);

                //savedPlayerTransform.Remove(t);
                //yield return new WaitForSecondsRealtime(replayCap);

            }

            isReplaying = false;
        }
    }*/


}
