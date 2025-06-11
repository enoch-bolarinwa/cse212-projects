using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    public static string AsString(this IEnumerable<int> source)
    {
         return $"<IEnumerable>{{{string.Join(", ", source)}}}";
    }
       
    
}

public class LinkedList : IEnumerable<int>
{
    private class Node
    {
        public int Data;
        public Node? Next;
        public Node? Prev;

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node? _head;
    private Node? _tail;

    public void InsertHead(int value)
    {
        Node newNode = new(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    public void InsertTail(int value)
    {
        Node newNode = new(value);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    public void RemoveHead()
    {
        if (_head == null)
        {
            return;
        }
        else if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            if (_head != null) _head.Prev = null;
        }
    }

    public void RemoveTail()
    {
        if (_tail == null)
        {
            return;
        }
        else if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            if (_tail != null) _tail.Next = null;
        }
    }

    public void InsertAfter(int value, int newValue)
    {
        Node? current = _head;
        while (current != null)
        {
            if (current.Data == value)
            {
                if (current == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Next = current.Next;
                    newNode.Prev = current;
                    if (current.Next != null)
                    {
                        current.Next.Prev = newNode;
                    }
                    current.Next = newNode;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void Remove(int value)
    {
        Node? current = _head;
        while (current != null)
        {
            if (current.Data == value)
            {
                if (_head == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else if (current == _head)
                {
                    RemoveHead();
                }
                else if (current == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        Node? current = _head;
        while (current != null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }
            current = current.Next;
        }
    }

    public IEnumerable <int> Reverse()
    {
        Node? current = _tail;
        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    public override string ToString()
    {
        List<int> values = new();
        Node? current = _head;
        while (current != null)
        {
            values.Add(current.Data);
            current = current.Next;
        }
        return $"<LinkedList>{{{string.Join(", ", values)}}}";
    }

    public bool HeadAndTailAreNull()
    {
        return _head == null && _tail == null;
    }

    public bool HeadAndTailAreNotNull()
    {
        return _head != null && _tail != null;
    }

    public IEnumerator<int> GetEnumerator()
    {
        Node? current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
