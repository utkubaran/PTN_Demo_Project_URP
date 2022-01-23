using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Character Data")]
public class PlayerData : ScriptableObject
{
    public int maxHealth;

    public float movementSpeed;
    
    public float rotationSpeed;
}
