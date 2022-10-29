using System.Net.NetworkInformation;

namespace DSALeetCode;

public interface IMinStack
{
    void Push(int value);
    void Pop();
    int Top();
    int GetMin();
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
public class MinStack : IMinStack
{
    private int[] _items = Array.Empty<int>();
    private int _min = int.MaxValue;
    private int _size;
    private int _capacity;

    public MinStack()
    {
    }

    public MinStack(IEnumerable<int> enumerable)
    {
        if (enumerable is IList<int> collection)
        {
            this._items = new int[collection.Count];
            this._size = collection.Count;
            for(var index = collection.Count - 1; index >= 0; index--)
            {
                var item = collection[index];
                if (item < _min)
                {
                    _min = item;
                }

                this._items[index] = item;
            }
        }
        else
        {
            this._items = new int[4];
            this._capacity = 4;
            this._size = 0;
            foreach (var item in enumerable)
            {
                Add(item);
            }
        }
    }

    public void Push(int val)
    {
        this.Add(val);
    }

    public void Pop()
    {
        this.Remove();
    }

    public int Top()
    {
        if(this._size == 0)
        {
            return -1;
        }
        return this._items[0];
    }

    public int GetMin()
    {
        return this._min;
    }

    #region Helper function

    private void Add(int item)
    {
        if(this._min > item)
        {
            this._min = item;
        }
        // if next item still in ranage of array
        if (this._size < this._items.Length)
        {
            var index = this._size - 1;
            while(index >= 0)
            {
                var current = this._items[index];
                this._items[index + 1] = current;
                --index;
            }
            ++this._size;
            this._items[0] = item;
        }
        // if next item is out of range, extends capacity and copy elements to new array
        else
        {
            this._capacity = this._size * 2;
            var newStack = new int[this._capacity];
            Array.Copy(this._items, 0, newStack, 1, this._items.Length);
            newStack[0] = item;
            this._items = newStack;
            ++this._size;
        }
    }

    private int Remove()
    {
        var top = this._items[0];
        if(top == this._min)
        {
            if(this._size == 1)
            {
                this._min = int.MaxValue;
                this._items[0] = default;
                --this._size;
                return top;
            }
            else
            {
                this._min = this._items[1];
            }
        }
        var index = 0;
        while(index < this._size - 1)
        {
            var nextItem = this._items[index + 1];
            this._items[index] = nextItem;
        }
        --this._size;
        return top;
    }

    #endregion
}
