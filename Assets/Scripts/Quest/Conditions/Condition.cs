using UnityEngine;

[ExecuteInEditMode]
public abstract class Condition : MonoBehaviour
{
    public abstract bool IsSatisfied();
}