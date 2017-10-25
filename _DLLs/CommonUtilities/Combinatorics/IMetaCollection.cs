
//// Copyright 2008 Adrian Akison
// Distributed under license terms of CPOL
// http://www.codeproject.com/info/cpol10.aspx

using System;
using System.Collections.Generic;
using System.Text;

namespace Facet.Combinatorics
{
    /// <summary>
    /// Interface for Permutations, Combinations...
    /// </summary>
    /// <remarks>
    /// and any other classes 
    /// that present a collection of collections based on an input collection.  
    /// The enumerators that this class inherits defines the mechanism 
    /// for enumerating through the collections.  
    /// </remarks>
    /// <typeparam name="T">
    /// The type of the elements in the collection, 
    /// not the type of the collection.
    /// </typeparam>
    interface IMetaCollection<T> : IEnumerable<IList<T>>
    {
        /// <summary>
        /// The count of items in the collection.  
        /// </summary>
        /// <remarks>
        /// This is not inherited from ICollection 
        /// since this meta-collection cannot be extended by users.
        /// </remarks>
        long Count { get; }

        /// <summary>
        /// The type of the meta-collection, 
        /// </summary>
        /// <remarks>
        /// determining how the collections are determined from the inputs.
        /// </remarks>
        GenerateOption Type { get; }

        /// <summary>
        /// The upper index of the meta-collection, 
        /// </summary>
        /// <remarks>
        /// which is the size of the input collection.
        /// </remarks>
        int UpperIndex { get; }

        /// <summary>
        /// The lower index of the meta-collection, 
        /// </summary>
        /// <remarks>
        /// which is the size of each output collection.
        /// </remarks>
        int LowerIndex { get; }
    }
}
