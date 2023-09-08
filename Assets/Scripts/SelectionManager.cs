using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    SelectionController selectionController;
  
    private int count = 0;
   
    [SerializeField]
    private int countplus1 = -1;
    [SerializeField]
    private int countplus2 = -1;


    private void Start()
    {
        selectionController = GetComponent<SelectionController>();
    }
    public void OnSelect2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            countplus2 *= -1;

            count += countplus2;
            Debug.Log("signed2");
            
            Debug.Log(count);
        }

    }
    public void OnSelect1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            countplus1 *= -1;

            count += countplus1;
            Debug.Log("signed1");
            
            Debug.Log(count);
        }

    }
       


    public void LoadArena()
    {
        SceneManager.LoadScene("ArenaScene");
    }
    private void FixedUpdate()
    {
        if(count==2)
        {
            LoadArena();
        }
    }
}
