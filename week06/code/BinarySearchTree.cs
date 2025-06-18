using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class BinarySearchTree
{
    private class Node
    {
        public int Value;
        public Node? Left, Right;

        public Node(int value)
        {
            Value = value;
        }
    }

    private Node? root;

    public void Insert(int value)
    {
        root = InsertRecursive(root, value);
    }

    private Node InsertRecursive(Node? node, int value)
    {
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = InsertRecursive(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRecursive(node.Right, value);
        // Duplicate values are ignored

        return node;
    }

    public bool Contains(int value)
    {
        return ContainsRecursive(root, value);
    }

    private bool ContainsRecursive(Node? node, int value)
    {
        if (node == null) return false;
        if (value == node.Value) return true;
        return value < node.Value
            ? ContainsRecursive(node.Left, value)
            : ContainsRecursive(node.Right, value);
    }

    public IEnumerable<int> Reverse()
    {
        var result = new List<int>();
        ReverseInOrder(root, result);
        return result;
    }

    private void ReverseInOrder(Node? node, List<int> result)
    {
        if (node == null) return;
        ReverseInOrder(node.Right, result);
        result.Add(node.Value);
        ReverseInOrder(node.Left, result);
    }

    public int GetHeight()
    {
        return GetHeightRecursive(root);
    }

    private int GetHeightRecursive(Node? node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(GetHeightRecursive(node.Left), GetHeightRecursive(node.Right));
    }

    public override string ToString()
    {
        var result = new List<int>();
        InOrderTraversal(root, result);
        return "<Bst>{" + string.Join(", ", result) + "}";
    }

    private void InOrderTraversal(Node? node, List<int> result)
    {
        if (node == null) return;
        InOrderTraversal(node.Left, result);
        result.Add(node.Value);
        InOrderTraversal(node.Right, result);
    }
}

public static class ExtensionMethods
{
    public static string AsString(this IEnumerable<int> sequence)
    {
        return "<IEnumerable>{" + string.Join(", ", sequence) + "}";
    }
}
