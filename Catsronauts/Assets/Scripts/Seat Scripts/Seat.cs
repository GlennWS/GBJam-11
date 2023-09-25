using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public bool _occupied = false;
    public bool _catDecided = false;
    private Cocktail cocktailChoice;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OccupySeat()
    {
        _occupied = true;
        _animator.SetBool("isOccupied", true);
        StartCoroutine(WaitToOrder());
    }

    public void VacateSeat()
    {
        _occupied = false;
        _catDecided = false;
        _animator.SetBool("isOccupied", false);
        _animator.SetBool("isDecided", false);
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    private IEnumerator WaitToOrder()
    {
        yield return new WaitForSeconds(3);
        cocktailChoice = Cocktails.GetRandomCocktail();
        _catDecided = true;
        _animator.SetBool("isDecided", true);
        Debug.Log(gameObject.name + " wants: " + cocktailChoice);
    }

    public Cocktail GetCocktailChoice()
    {
        return cocktailChoice;
    }
}
