using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity { get; private set; } = 0;

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[data.Length + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == data.Length) ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        public T Find(Func<T, bool> searchCriteria)
        {
            if (searchCriteria == null) throw new ArgumentNullException("Search criteria is null.");
            for (int i = 0; i < Count; i++)
            {
                if (searchCriteria(data[i])) return data[i];
            }
            return default(T);
        }
        public void Insert(int index, T element)
        {
            if (index > Count || index < 0) throw new IndexOutOfRangeException(nameof(element));
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);

            if (index == Count) data[Count] = element;
            for (int i = Count; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = element;
            Count++;
            
        }

        public void Clear()
        {
            data = new T[Capacity];
            Count = 0;        }

        public bool Contains(T element)
        {
            if (IndexOf(element) > -1)
                return true;
            return false;
        }

        public bool Remove(T element)
        {
            var index = IndexOf(element);
            if (index > -1)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException();
            for (int i = index; i < Count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            Count--;
            data[Count] = default(T);
        }

        public override string ToString()
        {
            string stringData = "";
            int i = 0;
            for (i = 0; i < Count - 1; i++)
                stringData += string.Format("{0}, ", data[i]);
            stringData += string.Format("{0}", data[i]);
            return stringData; throw new NotImplementedException();
        }

        public T Max()
        {
            
            Comparer<T> comparer = Comparer<T>.Default; //comparer to be used is the one specified in the tester file

            if (data.Length == 0) return default(T); //if the sequence is empty, return the default value for type T.

            T Max = data[0]; //Max is first element at 0th index of the sequence
            for (int i = 0; i < Count; i++) //loop through elements in the sequence
            {
                if (comparer.Compare(data[i], Max) == 1) //if the current element is larger than i...
                {
                    Max = data[i]; //the current element is the new max
                }
            }
            return Max; //return the maximum value in the sequence
        }

        public T Min()
        {
            Comparer<T> comparer = Comparer<T>.Default; //comparer to be used is the one specified in the tester file

            if (data.Length == 0) return default(T); //if the sequence is empty, return the default value for type T.

            T Min = data[0]; //Min is first element at 0th index of the sequence
            for (int i = 0; i < Count; i++)  //loop through elements in the sequence
            {
                if (comparer.Compare(data[i], Min) < 1) //if the currenr element is smaller than i...
                {
                    Min = data[i]; //the current element is new minimum
                }
            }
            return Min; //return the minimum value in the sequence
        }

        public Vector<T> FindAll(Func<T, bool> searchCriteria)
        {
            //throw an error if no search criteria is specified 
            if (searchCriteria == null) throw new ArgumentNullException();
            //new vector to contain all elements that match the search criteria
            Vector<T> FoundData = new Vector<T>(DEFAULT_CAPACITY);
            bool MatchesCriteria;
            
            for (int i = 0; i < Count; i++) //access each element in the sequence
            {
                MatchesCriteria = searchCriteria(data[i]); //does the current element match the search criteria?
                if (MatchesCriteria == true) //if the current element matches the search criteria...
                {
                    FoundData.Add(data[i]); //add it to the new sequence
                }
            }
            return FoundData; //return the sequence of matching elements
        }
        //this method returns the number of elements removed from Vector<T>
        public int RemoveAll(Func<T, bool> filterCriteria)
        {   
            //throw an error if no criteria for filtering is specified 
            if (filterCriteria == null) throw new ArgumentNullException();
            
            int RemovedData = 0; //initialise int 'RemovedData'. At this point no elements have been removed.

            //loop BACKWARDS through the sequence of elements, as each element after the element to be
            //removed then decreases by 1 after removal.
            for (int i = Count - 1; i >= 0; i--)             {
                if (filterCriteria(data[i])) //if the current element meets the filter criteria
                {
                    RemovedData++; //increase the number of elements by 1
                    RemoveAt(i); //remove the current element
                }
            }
            return RemovedData; //return the number of elements removed from the vector.
        }
    }
}
