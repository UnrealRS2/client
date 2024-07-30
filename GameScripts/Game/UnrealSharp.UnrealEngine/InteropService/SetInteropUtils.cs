﻿/*
    MIT License

    Copyright (c) 2024 UnrealSharp

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.

    Project URL: https://github.com/bodong1987/UnrealSharp
*/
// ReSharper disable MemberHidesStaticFromOuterClass
namespace UnrealSharp.UnrealEngine.InteropService;

/// <summary>
/// Class SetInteropUtils.
/// </summary>
public static unsafe class SetInteropUtils
{
    #region Interop Function Pointers     
    /// <summary>
    /// Class InteropFunctionPointers
    /// Since mono does not support setting delegate* unmanaged type fields directly through reflection,
    /// Therefore we cannot directly declare delegate* unmanaged fields and set them through reflection
    /// So we use this method to set it indirectly, first save the external function pointer to these IntPtr,
    /// and then solve it through forced type conversion when calling.Although this is a bit inconvenient,
    /// there is currently no other way unless Mono supports it in the future.
    /// ReSharper disable once CommentTypo
    /// @reference check here: https://github.com/dotnet/runtime/blob/main/src/mono/mono/metadata/icall.c#L2134  ves_icall_RuntimeFieldInfo_SetValueInternal
    /// </summary>
    private static class InteropFunctionPointers
    {
#pragma warning disable CS0649 // The compiler detected an uninitialized private or internal field declaration that is never assigned a value. [We use reflection to bind all fields of this class]
        /// <summary>
        /// The get element property of set
        /// </summary>
        public static readonly IntPtr GetElementPropertyOfSet;
        /// <summary>
        /// The get length of set
        /// </summary>
        public static readonly IntPtr GetLengthOfSet;
        /// <summary>
        /// The get element address of set
        /// </summary>
        public static readonly IntPtr GetElementAddressOfSet;
        /// <summary>
        /// The is set contains element
        /// </summary>
        public static readonly IntPtr IsSetContainsElement;
        /// <summary>
        /// The add set element
        /// </summary>
        public static readonly IntPtr AddSetElement;
        /// <summary>
        /// The remove set element
        /// </summary>
        public static readonly IntPtr RemoveSetElement;
        /// <summary>
        /// The clear set
        /// </summary>
        public static readonly IntPtr ClearSet;
#pragma warning restore CS0649

        /// <summary>
        /// static constructor
        /// </summary>
        static InteropFunctionPointers()
        {
            InteropFunctions.BindInteropFunctionPointers(typeof(InteropFunctionPointers));
        }
    }
    #endregion

    /// <summary>
    /// Gets the element property of set.
    /// </summary>
    /// <param name="propertyPtr">The property PTR.</param>
    /// <returns>nint.</returns>
    public static IntPtr GetElementPropertyOfSet(IntPtr propertyPtr)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)InteropFunctionPointers.GetElementPropertyOfSet)(propertyPtr);
    }

    /// <summary>
    /// Gets the length of set.
    /// </summary>
    /// <param name="addressPtr">The address PTR.</param>
    /// <param name="propertyPtr">The property PTR.</param>
    /// <returns>int.</returns>
    public static int GetLengthOfSet(IntPtr addressPtr, IntPtr propertyPtr)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>)InteropFunctionPointers.GetLengthOfSet)(addressPtr, propertyPtr);
    }

    /// <summary>
    /// Gets the element address of set by index
    /// </summary>
    /// <param name="addressPtr">The address PTR.</param>
    /// <param name="propertyPtr">The property PTR.</param>
    /// <param name="index">The index.</param>
    /// <returns>nint.</returns>
    public static IntPtr GetElementAddressOfSet(IntPtr addressPtr, IntPtr propertyPtr, int index)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, IntPtr>)InteropFunctionPointers.GetElementAddressOfSet)(addressPtr, propertyPtr, index);
    }

    /// <summary>
    /// check if this set has an element
    /// </summary>
    /// <param name="addressPtr">The address PTR.</param>
    /// <param name="propertyPtr">The property PTR.</param>
    /// <param name="targetPtr">The target PTR.</param>
    /// <returns>bool.</returns>
    public static bool IsSetContainsElement(IntPtr addressPtr, IntPtr propertyPtr, IntPtr targetPtr)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, bool>)InteropFunctionPointers.IsSetContainsElement)(addressPtr, propertyPtr, targetPtr);
    }

    /// <summary>
    /// Adds or set a new element to this set
    /// </summary>
    /// <param name="addressPtr">The address PTR.</param>
    /// <param name="propertyPtr">The property PTR.</param>
    /// <param name="targetPtr">The target PTR.</param>
    /// <returns>bool.</returns>
    public static bool AddSetElement(IntPtr addressPtr, IntPtr propertyPtr, IntPtr targetPtr)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, bool>)InteropFunctionPointers.AddSetElement)(addressPtr, propertyPtr, targetPtr);
    }

    /// <summary>
    /// Removes the target element in this set
    /// </summary>
    /// <param name="addressPtr">The address PTR.</param>
    /// <param name="propertyPtr">The property PTR.</param>
    /// <param name="targetPtr">The target PTR.</param>
    /// <returns>bool.</returns>
    public static bool RemoveSetElement(IntPtr addressPtr, IntPtr propertyPtr, IntPtr targetPtr)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, bool>)InteropFunctionPointers.RemoveSetElement)(addressPtr, propertyPtr, targetPtr);
    }

    /// <summary>
    /// Clears the set.
    /// </summary>
    /// <param name="addressPtr">The address PTR.</param>
    /// <param name="propertyPtr">The property PTR.</param>
    public static void ClearSet(IntPtr addressPtr, IntPtr propertyPtr)
    {
        ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)InteropFunctionPointers.ClearSet)(addressPtr, propertyPtr);
    }
}