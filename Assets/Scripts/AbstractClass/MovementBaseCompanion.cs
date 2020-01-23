using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBaseCompanion : MonoBehaviour
{
    public delegate void MovementCompanionEvent();
    public MovementCompanionEvent OnMovementCompanion;
}
