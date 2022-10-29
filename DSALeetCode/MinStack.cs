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
    private int?[] _items = Array.Empty<int?>();
    private int _min = int.MaxValue;
    private int _minIndex = -1;
    private int _size;
    private int _capacity;

    public MinStack()
    {
    }

    public MinStack(IEnumerable<int> enumerable)
    {
        if (enumerable is IList<int> list)
        {
            this.InitializeFromCollection(list, (int index) => list[index]);
        }

        if (enumerable is ICollection<int> collection)
        {
            this.InitializeFromCollection(collection, collection.ElementAt);
        }
        else
        {
            this._items = new int?[4];
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
        if (this._size == 0)
        {
            return -1;
        }

        return this._items[0]!.Value;
    }

    public int GetMin()
    {
        return this._min;
    }

    #region Helper function

    private void InitializeFromCollection(ICollection<int> collection, Func<int, int> getElementFunc)
    {
        this._items = new int?[collection.Count];
        this._size = collection.Count;
        for (var index = collection.Count - 1; index >= 0; index--)
        {
            var item = getElementFunc(index);
            if (item < _min)
            {
                this._min = item;
                this._minIndex = index;
            }

            this._items[index] = item;
        }
    }

    private void Add(int item)
    {
        if (this._min > item)
        {
            this._min = item;
            this._minIndex = 0;
        }

        // if next item still in ranage of array
        if (this._size < this._items.Length)
        {
            var index = this._size - 1;
            while (index >= 0)
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
            this._capacity = this._size != default ? this._size * 2 : 4;
            var newStack = new int?[this._capacity];
            Array.Copy(this._items, 0, newStack, 1, this._items.Length);
            newStack[0] = item;
            this._items = newStack;
            ++this._size;
        }
    }

    private void Remove()
    {
        if(this._size == 0)
        {
            return;
        }
        // get the top item and see if we need to find a min replacement
        var top = this._items[0];
        var needFindNewMin = top == this._min;
        // edge case, if size is one then remove it and reset min
        if (this._size == 1)
        {
            if (needFindNewMin)
            {
                this._min = int.MaxValue;
                this._minIndex = -1;
            }
            this._items[0] = default;
            --this._size;
            return;
        }

        // loop through items
        // 1. move all elements index to the left (ie, subtract 1)
        // 2. if the element removed is the smallest element then we find a replacement
        var index = 0;
        var min = int.MaxValue;
        while (index < this._size)
        {
            // only replace min if value is smaller and index is different then current min
            int? current = this._items[index];
            if(needFindNewMin
                && min > current
                && index != this._minIndex)
            {
                this._minIndex = index - 1;
                min = current.Value;
            }
            // if at the last element reset to default
            if(index == this._size - 1)
            {
                this._items[index] = default;
            }
            // replace item with item on the right
            else
            {
                var nextItem = this._items[index + 1];
                this._items[index] = nextItem;
            }
            index++;
        }

        // replace min if needed with the element recorded
        if(needFindNewMin)
        {
            this._min = min;
        }
        else if(this._minIndex > 0)
        {
            --this._minIndex;
        }
        --this._size;
    }

    #endregion
}
