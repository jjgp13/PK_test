using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowMotto : MonoBehaviour
{

    [SerializeField] private Text textUI;

    private void OnEnable()
    {
        SetMottoInTextUI();
    }

    /// <summary>
    /// Selects a random motto and attached to the UI element
    /// </summary>
    private void SetMottoInTextUI()
    {
        List<string> mottos = LoadMotttos(LogicController.Instance.gender.ToString());

        int selectedMotto = Random.Range(0, mottos.Count);
        textUI.text = mottos[selectedMotto];
    }

    /*
     * This way it would be easier to only add mottos into the file and this will handle automatically the changes.
     * If the client need to add more mottos, shouldn't be a problem
     */

    /// <summary>
    /// Loads mottos file from Resoruces/Mottos location 
    /// </summary>
    /// <returns>String list of mottos wittin the file</returns>
    List<string> LoadMotttos(string file)
    {
        //Load a text file (Assets/Resources/Mottos/Mottos.txt)
        TextAsset mottoFile = Resources.Load<TextAsset>("Mottos/"+file);
        
        //Convert Text asset to a string and split it by lines
        string text = mottoFile.text;
        string[] lines = text.Split(System.Environment.NewLine.ToCharArray());

        //Some lines are returned as empty string. Skip those and add the mottos to the list
        List<string> mottos = new List<string>();
        foreach (string line in lines)
        {
            if (line != "")
                mottos.Add(line);
        }

        return mottos;
    }
}
