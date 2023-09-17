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
        timer += Time.deltaTime;
        Debug.Log(timer);

        if (timer >= 5.0f)
        {
            timer = 0f;

            int randomSeat = UnityEngine.Random.Range(0, seats.Length);
            GameObject currentSeat = seats[randomSeat];
            Seat scriptComponent = currentSeat.GetComponent<Seat>();

            if (scriptComponent._occupied == false)
            {
                scriptComponent._occupied = true;
                int randomNum = UnityEngine.Random.Range(0, catSprites.Length);
                Sprite randomSprite = catSprites[randomNum];
                SpriteRenderer seatSpriteRenderer = currentSeat.GetComponent<SpriteRenderer>();
                seatSpriteRenderer.sprite = randomSprite;
            }

            Debug.Log(seats.Length);
            Array.Clear(seats, 0, seats.Length);
            Debug.Log(seats.Length);
            GameObject[] totalSeats = GameObject.FindGameObjectsWithTag("Seat");
            List<GameObject> tempSeatList = new List<GameObject>();

            for (int i = 0; i < totalSeats.Length; i++)
            {
                Seat currSeatComp = totalSeats[i].GetComponent<Seat>();
                if (currSeatComp._occupied == false)
                {
                    tempSeatList.Add(totalSeats[i]);
                }
            }

            seats = tempSeatList.ToArray();
        }
    }
}
