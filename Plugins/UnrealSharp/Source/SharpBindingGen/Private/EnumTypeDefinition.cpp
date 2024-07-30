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
#include "EnumTypeDefinition.h"

namespace UnrealSharp
{
    void FEnumFieldDefinition::Write(FJsonObject& InObject) const
    {        
        InObject.SetStringField(TEXT("Name"), Name);
        InObject.SetNumberField(TEXT("Value"), Value);
    }

    void FEnumFieldDefinition::Read(const FJsonObject& InObject)
    {
        Name = InObject.GetStringField(TEXT("Name"));
        Value = InObject.GetNumberField(TEXT("Value"));
    }

    FEnumTypeDefinition::FEnumTypeDefinition()
    {
        Type = static_cast<int>(EDefinitionType::Enum);
    }

    FEnumTypeDefinition::FEnumTypeDefinition(UEnum* InEnum, FTypeValidation* InTypeValidation) :
        FBaseTypeDefinition(InEnum, InTypeValidation)
    {
        Type = static_cast<int>(EDefinitionType::Enum);
        
        LoadFields(InEnum);
    }

    void FEnumTypeDefinition::LoadFields(const UEnum* InEnum)
    {
        Fields.Empty();

        const UEnum* Enum = InEnum;

        const int NumEnums = Enum->NumEnums();

        for (int i = 0; i < NumEnums; ++i)
        {
            FString EnumName = Enum->GetNameStringByIndex(i);

            if (i == NumEnums - 1 && EnumName.EndsWith(TEXT("_MAX")))
            {
                continue;
            }

            const int64 EnumValue = Enum->GetValueByIndex(i);

            FEnumFieldDefinition Field;
            Field.Name = EnumName;
            Field.Value = EnumValue;
            
            Fields.Add(Field);
        }
    }

    void FEnumTypeDefinition::Write(FJsonObject& InObject)
    {
        // compatible with C#
        InObject.SetStringField("$type", "UnrealSharpTool.Core.TypeInfo.EnumTypeDefinition, UnrealSharpTool.Core");

        Super::Write(InObject);

        TArray<TSharedPtr<FJsonValue>> TempFields;
        
        for (auto& Field : Fields)
        {
            TSharedPtr<FJsonObject> FieldObject = MakeShared<FJsonObject>();
            Field.Write(*FieldObject);
            TempFields.Add(MakeShared<FJsonValueObject>(FieldObject));
        }

        InObject.SetArrayField(TEXT("Fields"), TempFields);
    }

    void FEnumTypeDefinition::Read(FJsonObject& InObject)
    {
        Super::Read(InObject);

        for (const auto& FieldsRef = InObject.GetArrayField(TEXT("Fields")); auto& FieldObject : FieldsRef)
        {
            if (TSharedPtr<FJsonObject>* ObjectPtr = nullptr; FieldObject->TryGetObject(ObjectPtr) && ObjectPtr != nullptr)
            {
                FEnumFieldDefinition FD;
                FD.Read(**ObjectPtr);

                Fields.Add(FD);
            }
        }
    }
}
