using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExtraPokedexButton : MonoBehaviour
{
    public void Shiny_And_Flip_Button_Click()
    {
        AnimatedGifDrawer gifViewer;

        var gifViewerComponent = GameObject.Find("Battle Sprite Viewer");
        gifViewer = gifViewerComponent.GetComponent<AnimatedGifDrawer>();

        if ( (gifViewerComponent != null) && (gameObject.GetComponent<Image>().color == new Color(0, 0, 0, 1)) ) // We only continue if we are actually seeing a GIF AND the button is disabled (black)
        {
            gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 1); // Change to Red

            gifViewer.ChangeGIFForm(); 
        }

        else if ((gifViewerComponent != null) && (gameObject.GetComponent<Image>().color == new Color(1, 0, 0, 1))) // We only continue if we are actually seeing a GIF AND the button is disabled (black)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1); // Change to Red

            gifViewer.ChangeGIFForm();
        }
    }
}
