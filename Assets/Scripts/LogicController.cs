using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    //Unique instance. we can apply Singleton.
    private static LogicController _instance;

    //Access to the panels
    public GameObject mainPanel;
    public GameObject genderPanel;
    public GameObject imagePanel;
    public GameObject mottoPanel;

    public enum Gender
    {
        Male,
        Female,
        Other,
        NoSelected
    };

    public enum Selection
    {
        Image,
        Motto,
        NoSelected
    };

    public Gender gender;
    public Selection selection;
    
    //Make sure that the controller exists, if not we should created and assgined this.
    public static LogicController Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject logicController = new GameObject("LogicController");
                logicController.AddComponent<LogicController>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        gender = Gender.NoSelected;
        selection = Selection.NoSelected;
    }

    /// <summary>
    /// Go to panel functionality
    /// </summary>
    /// <param name="currentPanel">Panel that will be deactivated</param>
    public void GoToPanel(GameObject currentPanel)
    {
        //Hide current panel
        currentPanel.SetActive(false);

        //Check if gender has benn selected
        if (gender == Gender.NoSelected)
            genderPanel.SetActive(true);
        else
        {
            if (selection == Selection.Image)
                imagePanel.SetActive(true);
            if (selection == Selection.Motto)
                mottoPanel.SetActive(true);
        }
    }


    /// <summary>
    /// Back button functionalty. Go to previous panel showed
    /// </summary>
    /// <param name="currentPanel">Panel thal will be deactivated</param>
    public void GoToPreviousPanel(GameObject currentPanel)
    {
        //Check if gender has not been selected and gender panel is active;
        if (gender == Gender.NoSelected && genderPanel.activeSelf == true)
        {
            currentPanel.SetActive(false);
            mainPanel.SetActive(true);
            return;
        }

        //Hide current panel
        currentPanel.SetActive(false);

        //Check if genre was already selected if not, show it
        if (gender != Gender.NoSelected)
            mainPanel.SetActive(true);
        else
            genderPanel.SetActive(true);
    }

    /// <summary>
    /// Change selection enum given the button pressed
    /// </summary>
    /// <param name="option">Image, Motto, NoSelected</param>
    public void SelectionOption(string option)
    {
        if (option == "Image")
            selection = Selection.Image;
        else if (option == "Motto")
            selection = Selection.Motto;
        else
            Debug.Log("No option selected");
    }

    /// <summary>
    /// Change gender enum given the button pressed
    /// </summary>
    /// <param name="option">Male, Female, Other, NoSelected</param>
    public void GenderSelection(string genderStr)
    {
        if (genderStr == "Male")
            gender = Gender.Male;
        else if (genderStr == "Female")
            gender = Gender.Female;
        else if (genderStr == "Other")
            gender = Gender.Other;
        else
            Debug.Log("No gender Selected");
    }

}
