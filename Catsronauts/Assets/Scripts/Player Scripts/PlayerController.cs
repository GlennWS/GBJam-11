using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5.0f;
    public Transform[] seatPositions;
    public int _currSeatIndex = 0;
    RhythmController rhythmController;
    public static Action<Cocktail> onServeCocktail;
    public BeatScroller beatScroller;

    private int CurrSeatIndex
    {
        get { return _currSeatIndex; }
        set { _currSeatIndex = Mathf.Clamp(value, 0, 4); }
    }

    void Start()
    {

    }

    void Update()
    {
        if (!beatScroller.hasStarted)
        {
            // Player movement
            if (Input.GetKeyDown(KeyCode.A))
            {
                CurrSeatIndex--;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                CurrSeatIndex++;
            }

            // Cat interaction
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject tempObj = GameObject.Find("Seat" + _currSeatIndex);
                Seat currSeat = tempObj.GetComponent<Seat>();
                if (currSeat._occupied == true && currSeat._catDecided == false)
                {
                    Debug.Log("there's a fat ass cat sitting here");
                }
                else if (currSeat._occupied == true && currSeat._catDecided == true)
                {
                    Cocktail order = currSeat.GetCocktailChoice();
                    onServeCocktail?.Invoke(order);
                }
                else
                {
                    Debug.Log("there's not a fat ass cat sitting here");
                }
            }

            Vector3 newPos = seatPositions[CurrSeatIndex].position;
            newPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
        }
    }
}
