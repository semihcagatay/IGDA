using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameObject spawnedCharacter;
   // private string selectedCharacter=SelectionController.SelectedCharacter;
   /* public string SelectedCharacter
    {
        get {return _selectedCharacter; }
        set {value= _selectedCharacter;  }
    }*/
    
    // Start is called before the first frame update
  /*  void Awake()
    {
        spawnedCharacter = Resources.Load<GameObject>("Prefabs/"+selectedCharacter);
        SpawnCharacter(spawnedCharacter);
        Debug.Log(selectedCharacter);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
   /* public void SpawnCharacter(GameObject spawnCh)
    {
        if(spawnCh != null) 
        {
            Instantiate(spawnCh);
        }
        else
        {
            Debug.Log(("null"));
        }
        
    }*/
}
