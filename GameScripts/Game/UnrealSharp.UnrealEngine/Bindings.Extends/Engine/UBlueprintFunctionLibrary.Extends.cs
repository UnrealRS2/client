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
using UnrealSharp.UnrealEngine.InteropService;

namespace UnrealSharp.UnrealEngine;

/// <summary>
/// Class UBlueprintFunctionLibrary.
/// Implements the <see cref="UnrealSharp.UnrealEngine.UObject" />
/// </summary>
/// <seealso cref="UnrealSharp.UnrealEngine.UObject" />
public partial class UBlueprintFunctionLibrary
{
    /// <summary>
    /// Special classes like UBlueprintFunctionLibrary are allowed to have constructors without parameters, 
    /// and theoretically we will not create object instances of these static classes.
    /// Initializes a new instance of the <see cref="UBlueprintFunctionLibrary"/> class.
    /// </summary>
    public UBlueprintFunctionLibrary() :
        base(ObjectInteropUtils.GetDefaultObjectPointerOfClass(StaticClass().GetNativePtr()))
    {
    }
}