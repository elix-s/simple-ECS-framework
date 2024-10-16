using System;
using UnityEngine;

public abstract class Component
{
    public event Action OnStateChanged;
    
    protected void NotifyStateChanged()
    {
        OnStateChanged?.Invoke();
    }
    
    public virtual void LogState()
    {
        Debug.Log($"State of {GetType().Name}: {this}");
    }
}
