using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sudoku.Models.Impl
{

    public class Number : MonoBehaviour, IPointerClickHandler
    {

        public static event Action<string> selectedNumber;

        [SerializeField] private GameObject numberValueText;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!numberValueText.TryGetComponent<Text>(out Text text)) return;
  
            selectedNumber?.Invoke(text.text);
        }
    }



}
