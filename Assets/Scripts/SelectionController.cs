using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SelectionController : MonoBehaviour
{
    public GameObject[] GO = new GameObject[2];
    public Vector2 moveInput=Vector2.zero;
    Collider2D col;
    SelectionManager SM;
    public static string SelectedCharacter1;
    public static string SelectedCharacter2;
    

    

    /* int leftXconstrains, rightXconstrains;
     int topYconstrains, bottomYconstrains;*/

    // Start is called before the first frame update
    void Start()
    {
    col=GetComponent<Collider2D>();

    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
  

        //transform.position = new Vector2(transform.position.x + Convert.ToInt32(moveInput.x * 1), transform.position.y + Convert.ToInt32(moveInput.y * 1));

    }*/
   


public void Onmove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        transform.Translate(new Vector2(moveInput.x/2,moveInput.y/2));

    }
    

   
    /*public void OnTriggerEnter2D(Collider2D collision)
    {
       
        Debug.Log("triggered");
        SM = GetComponent<SelectionManager>();
        switch (collision.name)
        {
            case "Char1":
                SM.GO[0].SetActive(true);
                SelectedCharacter = "Legioner";
                break;
            case "Char2":
                SM.GO[1].SetActive(true);
                SelectedCharacter = "Woman";
                break;
        }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("untriggered");
        SM = GetComponent<SelectionManager>();
        switch (collision.name)
        {
            case "Char1":
                SM.GO[0].SetActive(false);
                    break;
            case "Char2":
                SM.GO[1].SetActive(false);
                break;

        }

    }*/

    public void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("triggered");
        
        switch (collision.name)
        {
            case "Char1":
                GO[0].SetActive(true);
                if(gameObject.name =="Selection_1")
                SelectedCharacter1 = "Legioner";
                else
                SelectedCharacter2 = "Legioner";
                break;

            case "Char2":
                GO[1].SetActive(true);
                if (gameObject.name == "Selection_1")
                    SelectedCharacter1 = "Woman";
                else
                    SelectedCharacter2 = "Woman";
                break;

        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("untriggered");
        
        switch (collision.name)
        {
            case "Char1":
                GO[0].SetActive(false);
                break;
            case "Char2":
                GO[1].SetActive(false);
                break;

        } 
    }


}
        


