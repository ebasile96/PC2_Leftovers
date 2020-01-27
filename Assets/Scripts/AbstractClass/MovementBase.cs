using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : MonoBehaviour
{
    public delegate void MovementEvent();
    public MovementEvent OnMovement;
}
