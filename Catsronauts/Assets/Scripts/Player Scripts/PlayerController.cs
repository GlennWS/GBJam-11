using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5.0f;
    public Transform[] seatPositions;
    private int _currSeatIndex = 0;

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
        if (Input.GetKeyDown(KeyCode.A))
        {
            CurrSeatIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            CurrSeatIndex++;
        }

        Vector3 newPos = seatPositions[CurrSeatIndex].position;
        newPos.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
    }
}
