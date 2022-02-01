using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    public float movementSpeed;

    public float swerveSpeed;
    
    public float rotationSpeed;
}
