﻿/* Copyright (c) 2020 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using Gibbed.RED4.ScriptFormats.Definitions;

namespace Gibbed.RED4.ScriptFormats.Instructions
{
    [Instruction(Opcode.EnumConst)]
    public struct EnumConst
    {
        public const int ChainCount = 0;

        public EnumerationDefinition Enumeration;
        public EnumeralDefinition Enumeral;

        public EnumConst(EnumerationDefinition enumeration, EnumeralDefinition enumeral)
        {
            this.Enumeration = enumeration;
            this.Enumeral = enumeral;
        }

        internal static (object, uint) Read(IDefinitionReader reader)
        {
            var enumeration = reader.ReadReference<EnumerationDefinition>();
            var enumeral = reader.ReadReference<EnumeralDefinition>();
            return (new EnumConst(enumeration, enumeral), 16);
        }

        internal static uint Write(object argument, IDefinitionWriter writer)
        {
            var (enumeration, enumeral) = (EnumConst)argument;
            writer.WriteReference(enumeration);
            writer.WriteReference(enumeral);
            return 16;
        }

        public void Deconstruct(out EnumerationDefinition enumeration, out EnumeralDefinition enumeral)
        {
            enumeration = this.Enumeration;
            enumeral = this.Enumeral;
        }

        public override string ToString()
        {
            return $"({this.Enumeration}, {this.Enumeral})";
        }
    }
}
