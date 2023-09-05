using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SelectionController : MonoBehaviour
{
    
    public Vector2 moveInput=Vector2.zero;
    Collider2D col;
    SelectionManager SM;
    public static string SelectedCharacter;
    
    
   /* int leftXconstrains, rightXconstrains;
    int topYconstrains, bottomYconstrains;*/
    
    // Start is called before the first frame update
    void Start()
    {
    col=GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("signed");
            SelectCharacter();
        }

        //transform.position = new Vector2(transform.position.x + Convert.ToInt32(moveInput.x * 1), transform.position.y + Convert.ToInt32(moveInput.y * 1));

    }
    public void Onmove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        transform.Translate(new Vector2(moveInput.x/2,moveInput.y/2));

    }


    public void SelectCharacter()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        Debug.Log("triggered");
        SM = GetComponent<SelectionManager>();
        switch (collision.name)
        {
            case "Char1":
                SM.GO[0].SetActive(true);
                SelectedCharacter = "Player 1";
                break;
            case "Char2":
                SM.GO[1].SetActive(true);
                SelectedCharacter = "Capsule";
                break;
            case "Char3":
                SM.GO[2].SetActive(true);
                SelectedCharacter = "Circle";
                break;
            case "Char4":
                SM.GO[3].SetActive(true);
                SelectedCharacter = "Triangle";
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
            case "Char3":
                SM.GO[2].SetActive(false);
                break;
            case "Char4":
                SM.GO[3].SetActive(false);
                break;

        }

    }


 

}
        


