using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    
    public InputSystem_Actions inputs;
    public GameObject EnemyPrefab;

    private void Awake()
    {
        
        inputs = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Attack.performed += OnAttack;
        
    }

    private void OnAttack(InputAction.CallbackContext context)
    {        
            print("Enemy Destroy");
                     
    }

    private void OnDisable()
    {
        
        inputs.Player.Attack.performed -= OnAttack;
        inputs.Disable();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
}
