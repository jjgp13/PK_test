using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{
    [SerializeField] private Image imageUI;
    private List<Sprite> images;

    //Sets image everytime the panel is showed;
    private void OnEnable()
    {
        images = LoadImages(LogicController.Instance.gender.ToString());
        SetImage();
    }

    /// <summary>
    /// Selects a random image and attached to the UI element
    /// </summary>
    private void SetImage()
    {
        int selectedImage = Random.Range(0, images.Count);
        imageUI.sprite = images[selectedImage];
        imageUI.SetNativeSize();
    }

    /*
     * If the client need to add more image, we should only include them in the Resources/Image folder
     */

    /// <summary>
    /// Loads images from Resoruces/Images location 
    /// </summary>
    /// <returns>Array with images in this location</returns>
    List<Sprite> LoadImages(string path)
    {
        List<Sprite> images = new List<Sprite>(Resources.LoadAll<Sprite>("Images/" + path));
        //Load a text file (Assets/Resources/Images)
        return images;
    }
}
