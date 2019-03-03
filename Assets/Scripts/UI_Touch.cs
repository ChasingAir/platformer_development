using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Touch : MonoBehaviour
{
void Update ()
  {
    // Check if there is a touch
     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
      {
       // Check if finger is over a UI element
        if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
       {
          Debug.Log("UI is touched");
          //so when the user touched the UI(buttons) call your UI methods
       }
       else
       {
        Debug.Log("UI is not touched");
       //so here call the methods you call when your other in-game objects are touched
       }
      }
    }
}
