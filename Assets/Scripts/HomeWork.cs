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
    /// ����� ��������� ������� OnClick ������ "����� ������ ����� ��������� ���������"
    /// </summary>
    public void OnSumEvenNumbersInRange()
    {
        int min = 7;
        int max = 21;
        var want = 98;
        int got = SumEvenNumbersInRange(min, max);
        string message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        Debug.Log($"����� ������ ����� � ��������� �� {min} �� {max} ������������: {got} - {message}");
        textField.text = message;
    }

    /// <summary>
    /// ����� ��������� ����� ������ ����� � ���������� ��������� 
    /// </summary>
    /// <param name="min">����������� �������� ���������</param>
    /// <param name="max">������������ �������� ���������</param>
    /// <returns>����� ����� ������ �����</returns>
    private int SumEvenNumbersInRange(int min, int max)
    {
        var evenNumbers = FindEvenNumbers(min, max);
        return evenNumbers.Sum();
    }

   
    /// <summary>
    /// ����� ��������� ������� OnClick ������ "����� ������ ����� � �������� �������"
    /// </summary>
    public void OnSumEvenNumbersInArray()
    {
        int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        int want = 214;
        int got = SumEvenNumbersInArray(array);
        string message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        Debug.Log($"����� ������ ����� � �������� �������: {got} - {message}");
        textField.text = message;
    }

    /// <summary>
    /// ����� ��������� ����� ������ ����� � ������� 
    /// </summary>
    /// <param name="array">�������� ������ �����</param>
    /// <returns>����� ����� ������ �����</returns>
    private int SumEvenNumbersInArray(int[] array)
    {
        var evenNumbers = FindEvenNumbers(array);
        return evenNumbers.Sum();
    }

    /// <summary>
    /// ����� ��������� ������� OnClick ������ "����� ������� ��������� ����� � ������"
    /// </summary>
    public void OnFirstOccurrence()
    {
        StringBuilder sb = new StringBuilder();
        // ������ ����, ����� ����������� � �������
        int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        int value = 34;
        int want = 3;
        int got = FirstOccurrence(array, value);
        string message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        Debug.Log($"������ ������� ��������� ����� {value} � ������: {got} - {message}");
        sb.AppendLine(message);

        // ������ ����, ����� �� ����������� � �������
        array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        value = 55;
        want = -1;
        got = FirstOccurrence(array, value);
        message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        Debug.Log($"������ ������� ��������� ����� {value} � ������: {got} - {message}");
        sb.AppendLine(message);
        textField.text = sb.ToString();
    }

    /// <summary>
    /// ����� ���������� ����� ������� ��������� ����� � ������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <param name="value">������� �����</param>
    /// <returns>������ �������� ����� � ������� ��� -1 ���� ����� ����������</returns>
    private int FirstOccurrence(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value) return i;
        }
        return -1;
    }

    /// <summary>
    /// ����� ��������� ������� OnClick ������ "���������� �������"
    /// </summary>
    public void OnSelectionSort()
    {
        StringBuilder sb = new StringBuilder();
        int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        Debug.LogFormat("�������� ������ {0}", "[" + string.Join(",", originalArray) + "]");
        sb.AppendLine($"�������� ������ {string.Join(",", originalArray)}");

        int[] sortedArray = SelectionSort((int[])originalArray.Clone());
        Debug.LogFormat("��������� ���������� {0}", "[" + string.Join(",", sortedArray) + "]");
        sb.AppendLine($"��������� ���������� {string.Join(",", sortedArray)}");

        int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
        var passed = sortedArray.SequenceEqual(expectedArray);
        Debug.Log(passed ? "��������� ������" : "��������� �� ������");
        sb.AppendLine(passed ? "��������� ������" : "��������� �� ������");
        textField.text = sb.ToString();
    }

    #region UTILITIES

    /// <summary>
    /// ����� ��������� ������ ������� ������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <returns>��������������� ������</returns>
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
