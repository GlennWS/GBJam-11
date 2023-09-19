using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public bool _occupied = false;
    public bool _catDecided = false;
    private Cocktail cocktailChoice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OccupySeat()
    {
        _occupied = true;
        StartCoroutine(WaitToOrder());
    }

    private IEnumerator WaitToOrder()
    {
        yield return new WaitForSeconds(10);
        cocktailChoice = Cocktails.GetRandomCocktail();
        _catDecided = true;
        Debug.Log(gameObject.name + " wants: " + cocktailChoice);
    }

    public Cocktail GetCocktailChoice()
    {
        return cocktailChoice;
    }
}
