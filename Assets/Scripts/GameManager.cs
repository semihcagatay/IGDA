using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject spawnedCharacter1;
    GameObject spawnedCharacter2;
    private string selectedCharacter1=SelectionController.SelectedCharacter1;
    private string selectedCharacter2=SelectionController.SelectedCharacter2;
    /*public string SelectedCharacter
    {
        get {return _selectedCharacter; }
        set {value= _selectedCharacter;  }
    }*/
    
    // Start is called before the first frame update
   void Awake()
    {
        spawnedCharacter1 = Resources.Load<GameObject>("Prefabs/"+selectedCharacter1);
        spawnedCharacter2 = Resources.Load<GameObject>("Prefabs/"+selectedCharacter2);
        SpawnCharacter(spawnedCharacter1,spawnedCharacter2);
        Debug.Log(selectedCharacter1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void SpawnCharacter(GameObject spawnCh1,GameObject spawnCh2)
    {
        if(spawnCh1 != null && spawnCh2!=null) 
        {
            Instantiate(spawnCh1);
            Instantiate(spawnCh2, new Vector2(7f, -2f), spawnCh2.transform.rotation);
        }
        else
        {
            Debug.Log(("null"));
        }
        
    }
}
