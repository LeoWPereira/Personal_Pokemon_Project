using UnityEngine;
using UnityEngine.UI;

public class PokedexButton : MonoBehaviour
{
    private int _pokemonNumber = 1;

    public PokedexScrollView ScrollView;
    public Button PokemonButton;
    
    public void SetImage(int pokemonIndex)
    {
        _pokemonNumber = pokemonIndex;

        Sprite pokemonSprite = Resources.Load<Sprite>("Sprites/Menu Icon Sprites/" + pokemonIndex); // Make sure not to include the file extension
        
        PokemonButton.image.sprite = pokemonSprite;
    }

    public void Button_Click ()
    {
        ScrollView.ButtonClicked(_pokemonNumber);
    }
}