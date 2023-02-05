using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValues : ScriptableObject, ISerializationCallbackReceiver
{

    public float initialValue;

    public float RuntimeValue;

    public void OnBeforeSerialize()
    { }

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }
}
