using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour
{
    #region Public Variables Declaration

    public float buttonWidth = 160.0f;
    public float buttonHeight = 20.0f;
    
    #endregion

    bool GUIEnabled = false;

    float screenCenterWidth = Screen.width / 2.0f;
    float screenCenterHeight = Screen.height / 2.0f;
    float spacingBetweenButtons = 30.0f;
    float offset = 1.6f; // offset in %

    void Update ()
    {
        if (Input.GetKeyDown("escape"))
            GUIEnabled = !GUIEnabled;
    }

    void OnGUI ()
    {
        float menuHeightPosition = screenCenterHeight * offset;

        if (GUIEnabled)
        {
            if (GUI.Button(new Rect(screenCenterWidth, menuHeightPosition - (spacingBetweenButtons * 2), buttonWidth, buttonHeight), "Options"))
            {

            }

            if (GUI.Button(new Rect(screenCenterWidth, menuHeightPosition - spacingBetweenButtons, buttonWidth, buttonHeight), "Help"))
            {

            }

            if (GUI.Button(new Rect(screenCenterWidth, menuHeightPosition, buttonWidth, buttonHeight), "Return to Game"))
                GUIEnabled = !GUIEnabled;
        }
    }
}