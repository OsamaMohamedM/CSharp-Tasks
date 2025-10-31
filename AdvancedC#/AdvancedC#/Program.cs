using System.Collections;

namespace AdvancedC_
{
  internal class Program
  {
    static void Main(string[] args)
    {
      #region Generics
      Box<int> box = new Box<int>();
      box.Add(42);
      int item = box.GetItem();
      Console.WriteLine(item);
      #endregion

      #region List vs ArrayList
      #region List
      List<int> lst = new List<int>();
      lst.Add(1);
      lst.Add(2);
      lst.Add(3);
      foreach (var val in lst)
      {
        Console.WriteLine(val);
      }
      #endregion

      #region ArrayList
      ArrayList arrayList = new ArrayList();
      arrayList.Add(1);
      arrayList.Add("osama");
      arrayList.Add(true);
      int x = (int)arrayList[0];
      string y = (string)arrayList[1];
      bool z = (bool)arrayList[2];
      Console.WriteLine(x);
      Console.WriteLine(y);
      Console.WriteLine(z);

      /*
        Boxing:
         - Happens when a Value Type (like int) is converted to an Object.
         - The CLR allocates a new object on the Heap.
         - The value from the Stack (10, 20) is copied into that Heap object.
         - The ArrayList stores a reference (object) to that memory.

        Unboxing:
         - Happens when retrieving the value back as a Value Type.
         - The CLR checks the object type to ensure it's System.Int32.
         - If the type matches, it copies the value back from Heap → Stack.
         - If the type doesn’t match → InvalidCastException.

        Performance Notes:
         - Boxing/Unboxing causes extra memory allocations.
         - It also adds CPU overhead (type checking, copying).
         - Avoid frequent Boxing/Unboxing for performance-critical code.

        Example of Invalid Unboxing:
         double d = (double)arrayList[0]; // InvalidCastException (object is int)

        Better Alternative (Generics):
         Use List<int> to avoid Boxing/Unboxing:
         List<int> numbers = new List<int>();
         numbers.Add(10);
         int x = numbers[0]; //No Boxing or Unboxing   
      */
      #endregion
      #endregion

      #region HashTable vs Dictionary vs SortedList
      #region HashTable
      //  Hashtable
      // - Non-generic collection (stores as object)
      // - Key and Value are of type object
      // - Does NOT maintain any specific order
      // - Slower because of boxing/unboxing with value types
      Hashtable ht = new Hashtable();
      ht.Add("key1", "value1");
      ht.Add(5, 3);
      ht.Add(true, false);
      foreach (KeyValuePair<object, object> pair in ht)
      {
        Console.WriteLine(pair.Key);
        Console.WriteLine(pair.Value);
      }
      #endregion
      #region Dictionary
      /*
         Dictionary<TKey, TValue>
         - Generic collection (type-safe, faster)
         - Does NOT maintain order
         - No boxing/unboxing
        */
      Dictionary<int, int> dic = new Dictionary<int, int>();
      dic.Add(1, 10);
      dic.Add(2, 20);
      dic.Add(3, 30);
      foreach (KeyValuePair<int, int> pair in dic)
      {
        Console.WriteLine(pair.Key);
        Console.WriteLine(pair.Value);
      }
      #endregion
      #region SortedList
      // SortedList<TKey, TValue>
      // - Generic collection that keeps elements sorted by Key
      // - Maintains ascending order automatically
      // - Lookup: O(log n)
      SortedList<int, int> sl = new SortedList<int, int>();
      sl.Add(1, 5);
      sl.Add(2, 5);
      sl.Add(3, 5);
      foreach (KeyValuePair<int, int> pair in sl)
      {
        Console.WriteLine(pair.Key);
        Console.WriteLine(pair.Value);
      }
      #endregion
      #endregion

      #region Stack vs Queue
      #region Stack
      Stack<int> stack = new Stack<int>();
      stack.Append(5);
      stack.Append(0);
      stack.Append(2);
      stack.Append(1);
      foreach (var val in stack)
        Console.WriteLine(val);
      int top = stack.Pop();
      Console.WriteLine(top);
      #endregion
      #region Queue
      Queue<int> queue = new Queue<int>();
      queue.Enqueue(5);
      queue.Enqueue(0);
      queue.Enqueue(2);
      queue.Enqueue(1);
      foreach (var val in queue)
        Console.WriteLine(val);
      int front = queue.Dequeue();
      Console.WriteLine(front);
      #endregion
      #endregion

      #region Tuple vs ValueTuple
      // Old-style Tuple
      // - Immutable (cannot change values)
      // - Reference type (stored on heap)
      // - Access elements with Item1, Item2, Item3...
      Tuple<int, string, bool> oldTuple = new Tuple<int, string, bool>(25, "Osama", true);

      Console.WriteLine("Old Tuple:");
      Console.WriteLine(oldTuple.Item1); // 25
      Console.WriteLine(oldTuple.Item2); // Osama
      Console.WriteLine(oldTuple.Item3); // True

      // Attempt to change value (Not allowed)
      // oldTuple.Item1 = 26; //Compile error

      Console.WriteLine("\n----------------------\n");
      // New-style ValueTuple
      // - Mutable (can change values)
      // - Value type (stored on stack, faster)
      // - Supports named elements for cleaner code
      (int Age, string Name, bool IsActive) valueTuple = (25, "Osama", true);

      Console.WriteLine("ValueTuple:");
      Console.WriteLine(valueTuple.Age);      // 25
      Console.WriteLine(valueTuple.Name);     // Osama
      Console.WriteLine(valueTuple.IsActive); // True
      valueTuple.Age = 26;
      Console.WriteLine("After update Age: " + valueTuple.Age); // 26
      var (age, name, active) = valueTuple;
      Console.WriteLine("\nDeconstructed Values:");
      Console.WriteLine(age);    // 26
      Console.WriteLine(name);   // Osama
      Console.WriteLine(active); // True

      // Advantages of ValueTuple:
      // 1. Cleaner syntax (named elements)
      // 2. Mutable
      // 3. Faster (value type, stored on stack)
      // 4. Easy deconstruction
      #endregion
      
      #region IEnumerator and IEnumerable
      CustomClass<int> myCollection = new CustomClass<int>();
      myCollection.Add(10);
      myCollection.Add(20);
      myCollection.Add(30);
      Console.WriteLine("Count: " + myCollection.Count());
      foreach (var val in myCollection)
      {
        Console.WriteLine(item);
      }
      #endregion

      #region Indexer
      Console.WriteLine(myCollection[0]);
      myCollection[2] = 1;
      Console.WriteLine(myCollection[2]);
      #endregion
    }
  }
}

/*
IEnumerable / IEnumerable<T>
Purpose: Makes a collection iterable (usable in foreach loops).
Key Method: GetEnumerator() → returns an IEnumerator.
Generic version (IEnumerable<T>): Type-safe iteration without boxing/unboxing.
Use Case:
Whenever you want to loop over a collection.
Supports LINQ queries.
IEnumerator / IEnumerator<T>
Purpose: Controls the actual iteration over a collection.
Key Members:
MoveNext() → moves to the next element, returns false at the end.
Current → gets the current element at the iterator’s position.
Reset() → resets the iterator to before the first element.
Dispose() → releases any resources (files, DB connections, etc.).
Use Case:
Manual iteration instead of foreach.
foreach internally uses this interface.
IEquatable<T>
Purpose: Provides type-safe equality comparison for objects of the same type.
Key Method: bool Equals(T other) → defines what makes two objects equal.
Defines how this object is equal to another of the same type.
IEqualityComparer<T>
Purpose: Provides external/custom equality logic and hash code for objects.
Key Methods:
bool Equals(T x, T y) → defines equality between two objects.
int GetHashCode(T obj) → provides hash code for collection lookup.
Used externally by the collection to determine if elements are equal.
Hash code is used for fast lookup in hash-based collections
*/