using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public Cocktail currentOrder;
    public List<GameObject> notePrefabs;
    //public Vector3 initialNote;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public float SetNotePlacements(GameObject parent)
    {
        float totalBeats = Songlist.GetSongBeats(currentOrder.ToString());
        //Vector3 initialBeatPrefabPos = initialNote;
        for (int i = 0; i < totalBeats; i++)
        {
            GameObject newNote = Instantiate(notePrefabs[UnityEngine.Random.Range(0, notePrefabs.Count)], parent.transform);
            newNote.transform.position = new Vector3(-7 - i, 4, 0.0f);
        }
        return (11.6f / beatTempo);
    }
}
