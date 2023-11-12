using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScaleText : MonoBehaviour
{
    public static void FitTextInContainer(Text text, RectTransform textContainer)
    {
        float originalFontSize = text.fontSize;

        float containerWidth = textContainer.rect.width;
        float containerHeight = textContainer.rect.height;

        text.fontSize = Mathf.FloorToInt(originalFontSize);

        // Пока текст не помещается в контейнере, уменьшайте размер шрифта.
        while (text.preferredWidth > containerWidth && text.preferredHeight > containerHeight)
        {
            text.fontSize = Mathf.Max(text.fontSize - 1, 1); // Уменьшаем размер шрифта на 1 пиксель.
        }
    }
}
