using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    Damageble playerdamageble;
    public Slider healthSlider;
    RectTransform healthRectTransform;
    private void Awake()
    {

        //GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        playerdamageble = player.GetComponent<Damageble>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        healthRectTransform = GetComponent<RectTransform>();
        healthSlider.value = calculateCurrentHealth(playerdamageble.Health,playerdamageble.MaxHealth);

    }
    private void FixedUpdate()
    {
        healthRectTransform.position = new Vector2(-95+transform.parent.parent.localPosition.x,-240+transform.parent.parent.localPosition.y+10);
    }
    public void OnEnable()
    {
        playerdamageble.calculateHealth.AddListener(healthChanged);
    }
    public void OnDisable()
    {
        playerdamageble.calculateHealth.RemoveListener(healthChanged);
    }

    private float calculateCurrentHealth(float currentHealth,float maxHealth)
    {
       return currentHealth/maxHealth;
    }
    private void healthChanged(float currentHealth,float maxHealth)
    {
        healthSlider.value = calculateCurrentHealth(currentHealth, maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
