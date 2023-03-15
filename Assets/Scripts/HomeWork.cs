using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HomeWork : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textField;

    /// <summary>
    /// Метод обработки события OnClick кнопки "Сумма четных чисел заданного диапазона"
    /// </summary>
    public void OnSumEvenNumbersInRange()
    {
        int min = 7;
        int max = 21;
        var want = 98;
        int got = SumEvenNumbersInRange(min, max);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Сумма четных чисел в диапазоне от {min} до {max} включительно: {got} - {message}");
        textField.text = message;
    }

    /// <summary>
    /// Метод вычисляет сумму четных чисел в заданноном диапазане 
    /// </summary>
    /// <param name="min">Минимальное значение диапазона</param>
    /// <param name="max">Максимальное значение диапазона</param>
    /// <returns>Сумма чисел четных чисел</returns>
    private int SumEvenNumbersInRange(int min, int max)
    {
        var evenNumbers = FindEvenNumbers(min, max);
        return evenNumbers.Sum();
    }

   
    /// <summary>
    /// Метод обработки события OnClick кнопки "Сумма четных чисел в заданном массиве"
    /// </summary>
    public void OnSumEvenNumbersInArray()
    {
        int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        int want = 214;
        int got = SumEvenNumbersInArray(array);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Сумма четных чисел в заданном массиве: {got} - {message}");
        textField.text = message;
    }

    /// <summary>
    /// Метод вычисляет сумму четных чисел в массиве 
    /// </summary>
    /// <param name="array">Исходный массив чисел</param>
    /// <returns>Сумма чисел четных чисел</returns>
    private int SumEvenNumbersInArray(int[] array)
    {
        var evenNumbers = FindEvenNumbers(array);
        return evenNumbers.Sum();
    }

    /// <summary>
    /// Метод обработки события OnClick кнопки "Поиск первого вхождения числа в массив"
    /// </summary>
    public void OnFirstOccurrence()
    {
        StringBuilder sb = new StringBuilder();
        // Первый тест, число присутсвует в массиве
        int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        int value = 34;
        int want = 3;
        int got = FirstOccurrence(array, value);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");
        sb.AppendLine(message);

        // Второй тест, число не присутсвует в массиве
        array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        value = 55;
        want = -1;
        got = FirstOccurrence(array, value);
        message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");
        sb.AppendLine(message);
        textField.text = sb.ToString();
    }

    /// <summary>
    /// Метод производит поиск первого вхождения числа в массив
    /// </summary>
    /// <param name="array">Исходный массив</param>
    /// <param name="value">Искомое число</param>
    /// <returns>Индекс искомого числа в массиве или -1 если число отсуствует</returns>
    private int FirstOccurrence(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value) return i;
        }
        return -1;
    }

    /// <summary>
    /// Метод обработки события OnClick кнопки "Сортировка выбором"
    /// </summary>
    public void OnSelectionSort()
    {
        StringBuilder sb = new StringBuilder();
        int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        Debug.LogFormat("Исходный массив {0}", "[" + string.Join(",", originalArray) + "]");
        sb.AppendLine($"Исходный массив {string.Join(",", originalArray)}");

        int[] sortedArray = SelectionSort((int[])originalArray.Clone());
        Debug.LogFormat("Результат сортировки {0}", "[" + string.Join(",", sortedArray) + "]");
        sb.AppendLine($"Результат сортировки {string.Join(",", sortedArray)}");

        int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
        var passed = sortedArray.SequenceEqual(expectedArray);
        Debug.Log(passed ? "Результат верный" : "Результат не верный");
        sb.AppendLine(passed ? "Результат верный" : "Результат не верный");
        textField.text = sb.ToString();
    }

    #region UTILITIES

    /// <summary>
    /// Метод сортируем массив методом выбора
    /// </summary>
    /// <param name="array">Исходный массив</param>
    /// <returns>Отсортированный массив</returns>
    private int[] SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int smallestPosition = FindIndexOfLessNumber(array, i);
            Swap(ref array[i], ref array[smallestPosition]);
        }
        return array;
    }

    private int FindIndexOfLessNumber(int[] array, int startIndex)
    {
        var indexOfMinValue = startIndex;
        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] < array[indexOfMinValue])
            {
                indexOfMinValue = i;
            }
        }
        return indexOfMinValue;
    }

    private void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b; b = c;
    }
    private IEnumerable<int> FindEvenNumbers(int min, int max)
    {
        for (int i = min; i < max; i++)
        {
            if (i % 2 == 0) yield return i;
        }
    }

    private IEnumerable<int> FindEvenNumbers(IEnumerable<int> ints)
    {
        foreach (int i in ints)
        {
            if (i % 2 == 0) yield return i;
        }
    }
    #endregion
}
