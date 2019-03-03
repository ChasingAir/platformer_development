//This script should move the object towards the input quickly enough to not notice much delay, but feel soft / heavy.

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftDrag : MonoBehaviour //this script
{

  private Vector2 leftFingerPos = Vector2.zero;
  private Vector2 leftFingerLastPos = Vector2.zero;
  private Vector2 leftFingerMovedBy = Vector2.zero;

  public float slideMagnitudeX = 0f;
  public float slideMagnitudeY = 0f;
  public Rigidbody2D rb;
  public float moveSpeed = 1f;
  private Vector2 slideMagnitudeXY;
  private Vector2 targetPos;

    // Update is called once per frame should FixedUpdate be used here instead?
    void Update()
    {
      if (Input.touchCount > 0)
      {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        foreach (UnityEngine.Touch touch in Input.touches)

        if (touch.phase == TouchPhase.Began)
        {
            leftFingerPos = Vector2.zero;
            leftFingerLastPos = Vector2.zero;
            leftFingerMovedBy = Vector2.zero;

            slideMagnitudeX = 0f;
            slideMagnitudeY = 0f;

            // record start position
            leftFingerPos = touch.position;

        }

        else if (touch.phase == TouchPhase.Moved)
        {
            leftFingerMovedBy = touch.position - leftFingerPos; // or Touch.deltaPosition : Vector2
                                                                // The position delta since last change.
            leftFingerLastPos = leftFingerPos;
            leftFingerPos = touch.position;

            // slide horz
            slideMagnitudeX = leftFingerMovedBy.x / Screen.width;

            // slide vert
            slideMagnitudeY = leftFingerMovedBy.y / Screen.height;

        }

        else if (touch.phase == TouchPhase.Stationary)
        {
            leftFingerLastPos = leftFingerPos;
            leftFingerPos = touch.position;

            slideMagnitudeX = 0f;
            slideMagnitudeY = 0f;
        }

        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            slideMagnitudeX = 0f;
            slideMagnitudeY = 0f;
        }

      slideMagnitudeXY.x = slideMagnitudeX;
      slideMagnitudeXY.y = slideMagnitudeY;
      //rb.position = rb.position + slideMagnitudeXY; this doesnt't work because it superseeds unity Physics
      targetPos = rb.position + slideMagnitudeXY;
      rb.AddForce(((targetPos - rb.position) / Time.deltaTime) * moveSpeed);
    }
    else // if no fingers touching the screen
    {
      rb.velocity = new Vector2(0.0f, 0.0f);
      gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
      gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
    Debug.Log(Input.touchCount);
  }
}
