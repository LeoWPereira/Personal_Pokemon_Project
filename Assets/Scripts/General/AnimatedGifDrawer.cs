using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedGifDrawer : MonoBehaviour
{
    List<Texture2D> gifFrames = new List<Texture2D>();
    List<Sprite> gifImagesFrames = new List<Sprite>();

    private string m_ImagePath { get; set; }

    float speed = 0.5f;

    public void ChangeGIFForm()
    {
        //! Here we Clear the Frame List, so we can change the sprite to its actually desired form!
        gifImagesFrames.Clear();
        gifFrames.Clear();

        UnityEngine.Color black = new UnityEngine.Color(0, 0, 0, 1);
        UnityEngine.Color red = new UnityEngine.Color(1, 0, 0, 1);
        
        var shinyButton = GameObject.Find("ShinyButton");
        var flipButton = GameObject.Find("FlipPokemonButton");

        if ( (shinyButton.GetComponent<UnityEngine.UI.Image>().color == black) && (flipButton.GetComponent<UnityEngine.UI.Image>().color == black) )
            SetGIF(m_ImagePath + ".gif");

        else if ( (shinyButton.GetComponent<UnityEngine.UI.Image>().color == red) && (flipButton.GetComponent<UnityEngine.UI.Image>().color == black) )
            SetGIF(m_ImagePath + "s.gif");

        else if ( (shinyButton.GetComponent<UnityEngine.UI.Image>().color == black) && (flipButton.GetComponent<UnityEngine.UI.Image>().color == red) )
            SetGIF(m_ImagePath + "b.gif");

        else if ( (shinyButton.GetComponent<UnityEngine.UI.Image>().color == red) && (flipButton.GetComponent<UnityEngine.UI.Image>().color == red) )
            SetGIF(m_ImagePath + "sb.gif");
    }

    public void SetImagePathAndGIF(string imagePath)
    {
        m_ImagePath += imagePath;

        SetGIF(m_ImagePath + ".gif");
    }

    void SetGIF(string imagePath)
    {
        string loadingGifPath = imagePath;

        System.Drawing.Image gifImage = System.Drawing.Image.FromFile(loadingGifPath);

        var dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);

        int frameCount = gifImage.GetFrameCount(dimension);

        for (int i = 0; i < frameCount; i++)
        {
            gifImage.SelectActiveFrame(dimension, i);

            var frame = new Bitmap(gifImage.Width, gifImage.Height);

            System.Drawing.Graphics.FromImage(frame).DrawImage(gifImage, Point.Empty);

            var frameTexture = new Texture2D(frame.Width, frame.Height);

            for (int x = 0; x < frame.Width; x++)
                for (int y = 0; y < frame.Height; y++)
                {
                    System.Drawing.Color sourceColor = frame.GetPixel(x, y);
                    frameTexture.SetPixel(frame.Width - 1 + x, frame.Height - 1 - y, new Color32(sourceColor.R, sourceColor.G, sourceColor.B, sourceColor.A)); // for some reason, x is flipped
                }
            frameTexture.Apply();

            gifFrames.Add(frameTexture);

            //! Now we need to Convert every Texture2D into Sprite!
            gifImagesFrames.Add(Sprite.Create(gifFrames[i], new Rect(0, 0, gifFrames[i].width, gifFrames[i].height), new Vector2(0.5f, 0.5f)));
        }
        
        GetComponent<UnityEngine.UI.Image>().rectTransform.sizeDelta = new Vector2(gifFrames[0].width, gifFrames[0].height); // and resize the image just one time
    }

    void OnGUI()
    {
        GetComponent<UnityEngine.UI.Image>().sprite = gifImagesFrames[(int)(Time.frameCount * speed) % gifImagesFrames.Count];        
    }
}