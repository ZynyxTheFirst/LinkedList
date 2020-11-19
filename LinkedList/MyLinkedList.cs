using System;
using System.Collections;
using System.Collections.Generic;

public class MyLinkedList<T> : IEnumerable<Node<T>>
{
    public Node<T> first = null;
    public int Count
    {
        get;
        private set;
    } = 0;

    public Node<T> AddFirst(T data)
    {
        var node = new Node<T>(data);
        node.Next = first;
        first = node;
        Count++;
        return node;
    }

    public Node<T> AddLast(T data)
    {
        if (first == null)
        {
            AddFirst(data);
            return null;
        }
        else
        {
            var node = new Node<T>(data);

            Node<T> current = first;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
            Count++;
            return node;
        }
    }

    public void Clear()
    {
        first = null;
        Count = 0;
    }

    public bool Contains(T data)
    {
        var current = first;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }

        return false;
    }

    public Node<T> Find(T data)
    {
        var comparer = EqualityComparer<T>.Default;
        var current = first;
        while (current != null)
        {
            if (comparer.Equals(current.Data, data))
                return current;
            current = current.Next;
        }
        return null;
    }

    public void Remove(Node<T> node)
    {
        var current = first;

        if (node == null)
            throw new ArgumentNullException();
        else if (current == node)
        {
            first = first.Next;
            Count--;
            return;
        }
        while (current != null)
        {
            if (current.Next.Equals(node))
            {
                current.Next = current.Next.Next;
                Count--;
                return;
            }
            current = current.Next;
        }
        throw new InvalidOperationException();
    }
    public bool Remove(T data)
    {
        Node<T> node = Find(data);
        if (node != null)
        {
            Remove(node);
            return true;
        }
        return false;
    }
    public Node<T> Get(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException("Index: " + index);

        if (Count == 0)
            return null;

        if (index >= Count)
            index = Count - 1;

        var current = first;
        for (int i = 0; i < index; i++)
            current = current.Next;
        return current;
    }

    public Node<T> this[int index]
    {
        get { return this.Get(index); }
    }

    public void PrintList(MyLinkedList<T> list)
    {
        foreach (var node in list)
        {
            Console.WriteLine(node.Data);
        }
    }

    public IEnumerator<Node<T>> GetEnumerator()
    {
        Node<T> current = first;
        while (current != null)
        {
            yield return current;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}