namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.

using Lists;
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        
        return m_numItems;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds

        ListNode<T> node = First;
        if (index < 0 || index >= m_numItems)
        {
            return default(T);
        }
        for (int i = 0; i < index; i++)
        {   
            if(node == null)
            {
                return default(T);
            }
            node = node.Next;
        }
        return node.Value;
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list

        ListNode<T> addNode = new ListNode<T>(value);
        if (First == null)
        {
            First = addNode;
            Last = addNode;
        }
        else
        {
            Last.Next = addNode;
            Last = addNode;
        }
        m_numItems++;
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        
        if (index < 0 || index >= m_numItems)
        {
            return default(T);
        }

        ListNode<T> prev = null;
        ListNode<T> node = First;
        for (int i = 0; i < index; i++)
        {
            prev = node;
            node = node.Next;
        }

        T remove = node.Value;

        if (prev == null)
        {
            First = node.Next;
            if (First == null) Last = null;
        }
        else
        {
            prev.Next = node.Next;
            if (prev.Next == null) Last = prev;
        }

        m_numItems--;
        return remove;
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        
        First = null;
        m_numItems = 0;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        ListNode<T> node = First;
        while (node != null)
        {
        yield return node.Value;
        node = node.Next;        
        }
    }
}
