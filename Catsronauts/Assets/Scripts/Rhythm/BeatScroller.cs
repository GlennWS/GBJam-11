using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public Cocktail currentOrder;
    public List<GameObject> notePrefabs;
    public Vector3 initialNote;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        //initialNote = GameObject.Find(currentOrder.ToString()).transform.GetChild(0).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            
        } else
        {
            transform.position += new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        }
    }

    public void SetNotePlacements(GameObject parent)
    {
        float totalBeats = Mathf.Floor(Songlist.GetSongBeats(currentOrder.ToString()));
        Vector3 initialBeatPrefabPos = initialNote;
        for (int i = 1; i < totalBeats; i++)
        {
            GameObject newNote = Instantiate(notePrefabs[UnityEngine.Random.Range(0, notePrefabs.Count)], parent.transform);
            newNote.transform.position = new Vector3(initialBeatPrefabPos.x - i, initialBeatPrefabPos.y, 0.0f);
        }
    }
}
