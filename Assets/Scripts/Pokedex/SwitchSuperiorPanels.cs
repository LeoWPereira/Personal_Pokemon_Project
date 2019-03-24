using UnityEngine;

public class SwitchSuperiorPanels : MonoBehaviour
{
    private string mode;

    public GameObject pokemonSearchPanel;
    public GameObject pokemonGifPanel;
    public GameObject pokedexScrollView;

    public void SwitchSuperiorPanelToBack()
    {
        mode = "back";

        SwitchSuperiorPanel();
    }

    void SwitchSuperiorPanel()
    {
        if (mode == "back")
        {
            var gifViewerComponent = GameObject.Find("Battle Sprite Viewer");
            var shinyButton = GameObject.Find("ShinyButton");
            var flipButton = GameObject.Find("FlipPokemonButton");
            
            shinyButton.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 1);
            flipButton.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 1);
            
            Destroy(gifViewerComponent.GetComponent<AnimatedGifDrawer>());
            
            pokedexScrollView.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1 / 255.0f);

            pokemonSearchPanel.SetActive(true);
            pokemonGifPanel.SetActive(false);          
        }
    }
}