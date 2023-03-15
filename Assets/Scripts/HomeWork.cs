using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        // ������ ����, ����� ����������� � �������
        int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        int value = 34;
        int want = 3;
        int got = FirstOccurrence(array, value);
        string message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        Debug.Log($"������ ������� ��������� ����� {value} � ������: {got} - {message}");

        // ������ ����, ����� �� ����������� � �������
        array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        value = 55;
        want = -1;
        got = FirstOccurrence(array, value);
        message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        Debug.Log($"������ ������� ��������� ����� {value} � ������: {got} - {message}");
    }

    /// <summary>
    /// ����� ���������� ����� ������� ��������� ����� � ������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <param name="value">������� �����</param>
    /// <returns>������ �������� ����� � ������� ��� -1 ���� ����� ����������</returns>
    private int FirstOccurrence(int[] array, int value)
    {
        // ���������� ����� ������� ��������� �������� � ������ � ������� ��� ������,
        // ���� ������� �� ����������� � ������� ������� -1
        return -1;
    }

    /// <summary>
    /// ����� ��������� ������� OnClick ������ "���������� �������"
    /// </summary>
    public void OnSelectionSort()
    {
        int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        Debug.LogFormat("�������� ������ {0}", "[" + string.Join(",", originalArray) + "]");

        int[] sortedArray = SelectionSort((int[])originalArray.Clone());
        Debug.LogFormat("��������� ���������� {0}", "[" + string.Join(",", sortedArray) + "]");

        int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
        Debug.Log(sortedArray.SequenceEqual(expectedArray) ? "��������� ������" : "��������� �� ������");
    }

    /// <summary>
    /// ����� ��������� ������ ������� ������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <returns>��������������� ������</returns>
    private int[] SelectionSort(int[] array)
    {
        // ���������� ���������� ������� ������� ������ � ������ ���������
        return array;
    }

    #region UTILITIES
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
