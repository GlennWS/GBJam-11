using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] catSprites;
    private GameObject[] seats;
    private float timer = 0f;

    void Start()
    {
        seats = GameObject.FindGameObjectsWithTag("Seat");
    }

    void Update()
    {
        // Accumulate elapsed time
        timer += Time.deltaTime;
        //Debug.Log(timer);

        // After 5 seconds have passed,
        if (timer >= 5.0f)
        {
            // Set the timer back to 0
            timer = 0f;

            // Then, select a random seat
            int randomSeat = UnityEngine.Random.Range(0, seats.Length);
            GameObject currentSeat = seats[randomSeat];
            Seat scriptComponent = currentSeat.GetComponent<Seat>();

            // If the seat is currently unoccupied,
            if (scriptComponent._occupied == false)
            {
                // It is now!
                scriptComponent.OccupySeat();
                // Select a random cat customer to occupy the seat :)
                int randomNum = UnityEngine.Random.Range(0, catSprites.Length);
                Sprite randomSprite = catSprites[randomNum];
                SpriteRenderer seatSpriteRenderer = currentSeat.GetComponent<SpriteRenderer>();
                seatSpriteRenderer.sprite = randomSprite;
            }

            // Empty the array of seats
            Array.Clear(seats, 0, seats.Length);
            GameObject[] totalSeats = GameObject.FindGameObjectsWithTag("Seat");
            List<GameObject> tempSeatList = new List<GameObject>();

            for (int i = 0; i < totalSeats.Length; i++)
            {
                // Find all of the seats that are currently unoccupied
                Seat currSeatComp = totalSeats[i].GetComponent<Seat>();
                if (currSeatComp._occupied == false)
                {
                    tempSeatList.Add(totalSeats[i]);
                }
            }

            // Add the unoccupied seats list to the original array
            seats = tempSeatList.ToArray();
        }
    }
}
