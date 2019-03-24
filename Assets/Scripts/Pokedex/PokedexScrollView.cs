using UnityEngine;

public class PokedexScrollView : MonoBehaviour
{
    public GameObject Button_Template;
    public GameObject GIF_Template;

    public GameObject PokemonGifPanel;
    
    // Use this for initialization
    void Start()
    {
        GameObject.Find("PokemonGIFViewer").SetActive(false);

        for (int i = 2 ; i <= 721; i++)
        {
            GameObject go = Instantiate(Button_Template) as GameObject;
            go.SetActive(true);

            PokedexButton PB = go.GetComponent<PokedexButton>();
            PB.SetImage(i);

            go.transform.SetParent(Button_Template.transform.parent);
        }
    }

    public void ButtonClicked(int pokemonIndex)
    {
        GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0); // 'Disable' the ScrollView alpha! (So we can see only the GIF)

        PokemonGifPanel.SetActive(true);
        
        var gifViewerComponent = GameObject.Find("Battle Sprite Viewer");
        
        AnimatedGifDrawer gifViewer = gifViewerComponent.AddComponent<AnimatedGifDrawer>();
        
        gifViewer.SetImagePathAndGIF("C:/Users/leona/Google Drive/Programming/Projetos/Unity/TQP - Pokemon Project/Assets/Resources/Sprites/Battle Sprites/" + pokemonIndex.ToString("000"));
    }
}