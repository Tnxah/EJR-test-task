using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    public virtual void Interaction()
    {
        print("Interaction with: " + this.name);
    }
}