using System;
using System.IO;
using System.Text;

namespace MCServerSharp.Data.Utils {
    public static unsafe class Util {
        public static readonly string SectionSign = "§";
        public static readonly Encoding UTF8 = Encoding.UTF8;

        #region Math
        /// <summary>
        /// Swap x and y when x > y
        /// </summary>
        public static void Sort(ref int x, ref int y) {
            if (x > y) {
                var tmp = x;
                x = y;
                y = tmp;
            }
        }
        #endregion Math

        #region BinaryConvert
        /// <summary>
        /// Read a sequence of bytes from a stream
        /// </summary>
        /// <param name="stream">The stream to read</param>
        /// <param name="count">The length of bytes to read</param>
        /// <returns>A byte array of length <paramref name="count"/> read from <paramref name="stream"/></returns>
        public static byte[] ReadBytes(this Stream stream, int count) {
            var buffer = new byte[count];
            var l = 0;
            while (l < count)
                l += stream.Read(buffer, l, count - l);
            return buffer;
        }
        /// <summary>
        /// Read a UTF-8 string prefixed with its size in bytes as a VarInt
        /// </summary>
        /// <param name="stream">The stream to read</param>
        public static string ReadString(this Stream stream) {
            return UTF8.GetString(stream.ReadBytes(stream.ReadVarInt()));
        }
        /// <summary>
        /// Get a UTF-8 string prefixed with its size in bytes as a VarInt from a buffer
        /// </summary>
        /// <param name="buffer">Buffer to read</param>
        public static string GetString(this ReadOnlySpan<byte> buffer) {
            return UTF8.GetString(buffer.Slice(buffer.ReadVarInt(out int i), i));
        }
        /// <summary>
        /// Get a UTF-8 string prefixed with its size in bytes as a VarInt from a buffer
        /// </summary>
        /// <param name="buffer">Buffer to read</param>
        /// <returns>Size of bytes read from <paramref name="buffer"/></returns>
        public static int GetString(this ReadOnlySpan<byte> buffer, out string output) {
            var j = buffer.ReadVarInt(out int i);
            output = UTF8.GetString(buffer[j..i]);
            return j + i;
        }
        /// <summary>
        /// Encode a string with UTF-8 and prefix with its size in bytes as a VarInt
        /// </summary>
        /// <param name="maxLength">Max length of the string</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the length of <paramref name="str"/> is larger than <paramref name="maxLength"/></exception>
        public static byte[] GetBytes(this ReadOnlySpan<char> str, int maxLength = 32767) {
            if (str.Length >= maxLength) throw new ArgumentOutOfRangeException(nameof(str), "The string is too long");
            var i = UTF8.GetByteCount(str);
            var vi = new VarInt(i).Buffer;
            var b = new byte[vi.Length + i];
            Buffer.BlockCopy(vi, 0, b, 0, vi.Length);
            UTF8.GetBytes(str, b.AsSpan()[vi.Length..]);
            return b;
        }
        #region Primitive Types
        /// <summary>
        /// Get bytes of a <see cref="short"/>
        /// </summary>
        public static ReadOnlySpan<byte> GetBytes(this in short value) {
            fixed (short* ptr = &value)
                return new(ptr, 2);
        }
        /// <summary>
        /// Get bytes of a <see cref="ushort"/>
        /// </summary>
        public static ReadOnlySpan<byte> GetBytes(this in ushort value) {
            fixed (ushort* ptr = &value)
                return new(ptr, 2);
        }
        /// <summary>
        /// Get bytes of a <see cref="int"/>
        /// </summary>
        public static ReadOnlySpan<byte> GetBytes(this in int value) {
            fixed (int* ptr = &value)
                return new(ptr, 4);
        }
        /// <summary>
        /// Get bytes of a <see cref="uint"/>
        /// </summary>
        public static ReadOnlySpan<byte> GetBytes(this in uint value) {
            fixed (uint* ptr = &value)
                return new(ptr, 4);
        }
        /// <summary>
        /// Get bytes of a <see cref="long"/>
        /// </summary>
        public static ReadOnlySpan<byte> GetBytes(this in long value) {
            fixed (long* ptr = &value)
                return new(ptr, 8);
        }
        /// <summary>
        /// Get bytes of a <see cref="ulong"/>
        /// </summary>
        public static ReadOnlySpan<byte> GetBytes(this in ulong value) {
            fixed (ulong* ptr = &value)
                return new(ptr, 8);
        }
        /// <summary>
        /// Get bytes of a <see cref="float"/>
        /// </summary>
        public static ReadOnlySpan<byte> GetBytes(this in float value) {
            fixed (float* ptr = &value)
                return new(ptr, 4);
        }
        /// <summary>
        /// Get bytes of a <see cref="double"/>
        /// </summary>
        public static ReadOnlySpan<byte> GetBytes(this in double value) {
            fixed (double* ptr = &value)
                return new(ptr, 8);
        }
        /// <summary>
        /// Read a <see cref="short"/> from a buffer
        /// </summary>
        public static short ToInt16(this ReadOnlySpan<byte> buffer) {
            fixed (byte* b = buffer)
                return *(short*)b;
        }
        /// <summary>
        /// Read a <see cref="int"/> from a buffer
        /// </summary>
        public static int ToInt32(this ReadOnlySpan<byte> buffer) {
            fixed (byte* b = buffer)
                return *(int*)b;
        }
        /// <summary>
        /// Read a <see cref="long"/> from a buffer
        /// </summary>
        public static long ToInt64(this ReadOnlySpan<byte> buffer) {
            fixed (byte* b = buffer)
                return *(long*)b;
        }
        /// <summary>
        /// Read a <see cref="float"/> from a buffer
        /// </summary>
        public static float ToSingle(this ReadOnlySpan<byte> buffer) {
            fixed (byte* b = buffer)
                return *(float*)b;
        }
        /// <summary>
        /// Read a <see cref="double"/> from a buffer
        /// </summary>
        public static double ToDouble(this ReadOnlySpan<byte> buffer) {
            fixed (byte* b = buffer)
                return *(double*)b;
        }
        #endregion Primitive Types
        /// <summary>
        /// Convert a byte to a hex string of length 2
        /// similar to <paramref name="value"/>.ToString("X2")
        /// </summary>
        /// <param name="high">First character of the hex string</param>
        /// <param name="low">Second character of the hex string</param>
        public static void ToHex(this byte value, out char high, out char low) {
            var i = value & 0xF;
            low = (char)(i > 9 ? i + 55 : i + 48); // A~F : 0~9
            i = value >> 4;
            high = (char)(i > 9 ? i + 55 : i + 48);
        }
        /// <summary>
        /// Convert a hex string of length 2 to a byte
        /// similar to byte.Parse(stringValue, NumberStyles.HexNumber);
        /// </summary>
        /// <param name="high">First character of the hex string</param>
        /// <param name="low">Second character of the hex string</param>
        public static void HexValue(this char high, char low, out byte output) {
            // A~F : 0~9
            output = (byte)((high > 64 ? high - 55 : high - 48) << 4 | (low > 64 ? low - 55 : low - 48));
        }
        #endregion BinaryConvert

        #region ReadVarInt
        /// <summary>
        /// Read a VarInt from a stream
        /// </summary>
        /// <param name="stream">The stream to read</param>
        /// <returns>Value of the VarInt</returns>
        public static int ReadVarInt(this Stream stream) {
            // Read out an Int32 7 bits at a time.
            // The high bit of the byte when on means to continue reading more bytes.
            var value = 0;
            var shift = 0;
            int b;
            do {
                if (shift >= 35)  // 5 bytes max per Int32, 5*7==35
                    throw new InvalidCastException("Too many bytes");
                b = stream.ReadByte();
                value |= (b & 0x7F) << shift;
                shift += 7;
            } while ((b & 0x80) != 0);
            return value;
        }
        /// <summary>
        /// Read a VarInt from a stream
        /// </summary>
        /// <param name="stream">The stream to read</param>
        /// <param name="varInt">Value of the VarInt</param>
        /// <returns>Length of bytes read from <paramref name="stream"/></returns>
        public static int ReadVarInt(this Stream stream, out int varInt) {
            // Read out an Int32 7 bits at a time.
            // The high bit of the byte when on means to continue reading more bytes.
            var value = 0;
            var shift = 0;
            int b;
            do {
                if (shift >= 35)  // 5 bytes max per Int32, 5*7==35
                    throw new InvalidCastException("Too many bytes");
                b = stream.ReadByte();
                value |= (b & 0x7F) << shift;
                shift += 7;
            } while ((b & 0x80) != 0);
            varInt = value;
            return shift / 7;
        }
        /// <summary>
        /// Read a VarInt from a buffer
        /// </summary>
        /// <param name="stream">The buffer to read</param>
        /// <returns>Value of the VarInt</returns>
        public static int ReadVarInt(this ReadOnlySpan<byte> buffer) {
            // Read out an Int32 7 bits at a time.
            // The high bit of the byte when on means to continue reading more bytes.
            var value = 0;
            var index = 0;
            var shift = 0;
            byte b;
            do {
                if (index >= 5)  // 5 bytes max per Int32, shift += 7
                    throw new InvalidCastException("Too many bytes");
                b = buffer[index++];
                value |= (b & 0x7F) << shift;
                shift += 7;
            } while ((b & 0x80) != 0);
            return value;
        }
        /// <summary>
        /// Read a VarInt from a buffer
        /// </summary>
        /// <param name="buffer">The buffer to read</param>
        /// <param name="varInt">Value of the VarInt</param>
        /// <returns>Length of bytes read from <paramref name="buffer"/></returns>
        public static int ReadVarInt(this ReadOnlySpan<byte> buffer, out int varInt) {
            // Read out an Int32 7 bits at a time.
            // The high bit of the byte when on means to continue reading more bytes.
            var value = 0;
            var index = 0;
            var shift = 0;
            byte b;
            do {
                if (index >= 5)  // 5 bytes max per Int32, shift += 7
                    throw new InvalidCastException("Too many bytes");
                b = buffer[index++];
                value |= (b & 0x7F) << shift;
                shift += 7;
            } while ((b & 0x80) != 0);
            varInt = value;
            return shift / 7;
        }
        /// <summary>
        /// Read a VarInt from a buffer
        /// </summary>
        /// <param name="buffer">The buffer to read</param>
        /// <param name="varInt">Value of the VarInt</param>
        /// <returns>Length of bytes read from <paramref name="buffer"/></returns>
        public static int ReadVarInt(this ReadOnlySpan<byte> buffer, out VarInt varInt) {
            var index = 0;
            byte b;
            do {
                if (index >= 5)  // 5 bytes max per Int32, shift += 7
                    throw new InvalidCastException("Too many bytes");
                b = buffer[index++];
            } while ((b & 0x80) != 0);
            varInt = new VarInt(buffer[..index].ToArray());
            return index;
        }
        #endregion VarInt
    }
}