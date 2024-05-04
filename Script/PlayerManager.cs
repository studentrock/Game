using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    public Vector2 position
    {
        get { return playerTransform.position; }
    }


}
