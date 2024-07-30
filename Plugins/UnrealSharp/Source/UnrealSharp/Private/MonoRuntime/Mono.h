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
#pragma once

#if WITH_MONO

#define MONO_RT_EXTERNAL_ONLY 

// include mono type definitions
#include <mono/metadata/details/image-types.h>
#include <mono/metadata/details/mono-debug-types.h>
#include <mono/metadata/details/mono-gc-types.h>
#include <mono/metadata/details/object-types.h>
#include <mono/metadata/details/class-types.h>
#include <mono/utils/details/mono-publib-types.h>
#include <mono/metadata/details/debug-helpers-types.h>
#include <mono/metadata/details/assembly-types.h>
#include <mono/jit/details/jit-types.h>
#include <mono/utils/details/mono-logger-types.h>
#include <mono/utils/details/mono-dl-fallback-types.h>
#include <mono/metadata/details/appdomain-types.h>
#include <mono/metadata/details/loader-types.h>

#if PLATFORM_WINDOWS || (WITH_EDITOR && PLATFORM_MAC || PLATFORM_LINUX)
#define UNREALSHARP_MONO_APIS_DYNAMIC_BINDING 1
#else
#define UNREALSHARP_MONO_APIS_DYNAMIC_BINDING 0
#endif


#if UNREALSHARP_MONO_APIS_DYNAMIC_BINDING
#define MONO_API_FUNCTION(returnType, name, params) \
    namespace UnrealSharp::Mono {\
        extern returnType(*name) params;\
    }
#else
#define MONO_API_FUNCTION(returnType, name, params) \
    extern "C"\
    { \
        extern returnType name params; \
    }
#endif

// include mono api definitions
#include "MonoRuntime/MonoApisImport.h"

#undef MONO_API_FUNCTION

#endif

