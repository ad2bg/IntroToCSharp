using System;

namespace CommonUtils
{
    /// <summary>
    /// Nullable boolean type.
    /// </summary>
    public struct DBBool
    {
        // The three possible DBBool values:
        public static readonly DBBool dbNull = new DBBool(0);
        public static readonly DBBool dbFalse = new DBBool(-1);
        public static readonly DBBool dbTrue = new DBBool(1);
        // Private field that stores -1, 0, 1 for dbFalse, dbNull, dbTrue:
        int value;

        // Private constructor. The value parameter must be -1, 0, or 1:
        DBBool(int value)
        {
            this.value = value;
        }

        // Implicit conversion from bool to DBBool.
        // Maps:
        // true to DBBool.dbTrue
        // false to DBBool.dbFalse
        public static implicit operator DBBool(bool x) => x ? dbTrue : dbFalse;

        // Explicit conversion from DBBool to bool.
        // Throws an exception if the given DBBool is dbNull,
        // otherwise returns true or false:
        public static explicit operator bool (DBBool x)
        {
            if (x.value == 0) throw new InvalidOperationException();
            return x.value > 0;
        }

        // Equality operator.
        // Returns dbNull if either operand is dbNull,
        // otherwise returns dbTrue or dbFalse:
        public static DBBool operator ==(DBBool x, DBBool y)
        {
            if (x.value == 0 || y.value == 0) return dbNull;
            return x.value == y.value ? dbTrue : dbFalse;
        }

        // Inequality operator.
        // Returns dbNull if either operand is dbNull,
        // otherwise returns dbTrue or dbFalse:
        public static DBBool operator !=(DBBool x, DBBool y)
        {
            if (x.value == 0 || y.value == 0) return dbNull;
            return x.value != y.value ? dbTrue : dbFalse;
        }

        // Logical negation operator.
        // Returns dbTrue if the operand is dbFalse,
        // dbNull if the operand is dbNull, or
        // dbFalse if the operand is dbTrue
        public static DBBool operator !(DBBool x) => new DBBool(-x.value);

        // Logical AND operator.
        // Returns dbFalse if either operand is dbFalse,
        // dbNull if either operand is dbNull,
        // otherwise dbTrue
        public static DBBool operator &(DBBool x, DBBool y) =>
            new DBBool(x.value < y.value ? x.value : y.value);

        // Logical OR operator.
        // Returns dbTrue if either operand is dbTrue,
        // dbNull if either operand is dbNull,
        // otherwise dbFalse
        public static DBBool operator |(DBBool x, DBBool y) =>
            new DBBool(x.value > y.value ? x.value : y.value);

        // Definitely true operator.
        // Returns true if the operand is dbTrue,
        // false otherwise
        public static bool operator true(DBBool x) =>
            x.value > 0;

        // Definitely false operator.
        // Returns true if the operand is dbFalse,
        // false otherwise
        public static bool operator false(DBBool x) =>
            x.value < 0;

        // Overload the conversion from DBBool to string:
        public static implicit operator string (DBBool x) =>
            x.value > 0 ? "dbTrue"
             : x.value < 0 ? "dbFalse" : "dbNull";

        // Override the Object.Equals(object obj) method:
        public override bool Equals(object obj)
        {
            try
            {
                return (bool)(this == (DBBool)obj);
            }
            catch
            {
                return false;
            }
        }

        // Override the Object.GetHashCode() method:
        public override int GetHashCode() => -1; //value; ???

        // Override the ToString method to convert DBBool to a string:
        public override string ToString()
        {
            switch (value)
            {
                case -1:
                    return "DBBool.False";
                case 0:
                    return "DBBool.Null";
                case 1:
                    return "DBBool.True";
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}