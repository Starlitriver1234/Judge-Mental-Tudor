using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrewExpression : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [Header("All Andrew Expressions in Order")]
    public Sprite[] expressions;

    public void SetExpression(int index)
    {
        if (index < 0 || index >= expressions.Length)
        {
            Debug.LogWarning("Expression index out of range: " + index);
            return;
        }

        spriteRenderer.sprite = expressions[index];
    }
}

