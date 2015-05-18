using System;
using System.Security;
using System.Text;

namespace LaMa.Framework.Core.Web.Helpers
{
    public class JavascriptBuilder
    {
        private readonly StringBuilder _stringBuilder;

        public JavascriptBuilder()

        {
            _stringBuilder = new StringBuilder();
        }

        public JavascriptBuilder(int capacity)
        {
            _stringBuilder = new StringBuilder(capacity);
        }

        public JavascriptBuilder(string value)
        {
            _stringBuilder = new StringBuilder(value);
        }

        public JavascriptBuilder(int capacity, int maxCapacity)

        {
            _stringBuilder = new StringBuilder(capacity, maxCapacity);
        }

        public JavascriptBuilder(string value, int capacity)

        {
            _stringBuilder = new StringBuilder(value, capacity);
        }

        public JavascriptBuilder(string value, int startIndex, int length, int capacity)

        {
            _stringBuilder = new StringBuilder(value, startIndex, length, capacity);
        }

        public int Capacity { get; set; }
        public int Length { get; set; }
        public int MaxCapacity { get; private set; }

        public char this[int index]
        {
            get { return _stringBuilder[index]; }
            set { _stringBuilder[index] = value; }
        }

        public JavascriptBuilder Append(bool value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(byte value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(char value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        [SecuritySafeCritical]
        public JavascriptBuilder Append(char[] value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(decimal value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(double value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(float value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(int value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(long value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(object value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(sbyte value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(short value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(string value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(uint value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(ulong value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(ushort value)

        {
            _stringBuilder.Append(value);

            return this;
        }

        public JavascriptBuilder Append(char value, int repeatCount)

        {
            _stringBuilder.Append(value, repeatCount);

            return this;
        }

        public JavascriptBuilder Append(char[] value, int startIndex, int charCount)

        {
            _stringBuilder.Append(value, startIndex, charCount);

            return this;
        }

        public JavascriptBuilder Append(string value, int startIndex, int count)

        {
            _stringBuilder.Append(value, startIndex, count);

            return this;
        }

        public JavascriptBuilder AppendFormat(string format, object arg0)

        {
            _stringBuilder.AppendFormat(format, arg0);

            return this;
        }

        public JavascriptBuilder AppendFormat(string format, params object[] args)

        {
            _stringBuilder.AppendFormat(format, args);

            return this;
        }

        public JavascriptBuilder AppendFormat(IFormatProvider provider, string format, params object[] args)

        {
            _stringBuilder.AppendFormat(provider, format, args);

            return this;
        }

        public JavascriptBuilder AppendLine()

        {
            _stringBuilder.AppendLine();

            return this;
        }

        public JavascriptBuilder AppendLine(string value)

        {
            _stringBuilder.AppendLine(value);

            return this;
        }

        public JavascriptBuilder Clear()

        {
            _stringBuilder.Clear();

            return this;
        }

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)

        {
            _stringBuilder.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        public int EnsureCapacity(int capacity)

        {
            return _stringBuilder.EnsureCapacity(capacity);
        }

        public bool Equals(JavascriptBuilder sb)

        {
            return _stringBuilder.Equals(sb);
        }

        public JavascriptBuilder Insert(int index, bool value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, byte value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, char value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, char[] value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, decimal value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, double value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, float value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, int value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, long value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, object value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, sbyte value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, short value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, string value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, uint value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, ulong value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, ushort value)

        {
            _stringBuilder.Insert(index, value);

            return this;
        }

        public JavascriptBuilder Insert(int index, string value, int count)

        {
            _stringBuilder.Insert(index, value, count);

            return this;
        }

        public JavascriptBuilder Insert(int index, char[] value, int startIndex, int charCount)

        {
            _stringBuilder.Insert(index, value, startIndex, charCount);

            return this;
        }

        public JavascriptBuilder Remove(int startIndex, int length)

        {
            _stringBuilder.Insert(startIndex, length);

            return this;
        }

        public JavascriptBuilder Replace(char oldChar, char newChar)

        {
            _stringBuilder.Replace(oldChar, newChar);

            return this;
        }

        public JavascriptBuilder Replace(string oldValue, string newValue)

        {
            _stringBuilder.Replace(oldValue, newValue);

            return this;
        }

        public JavascriptBuilder Replace(char oldChar, char newChar, int startIndex, int count)

        {
            _stringBuilder.Replace(oldChar, newChar, startIndex, count);

            return this;
        }

        public JavascriptBuilder Replace(string oldValue, string newValue, int startIndex, int count)

        {
            _stringBuilder.Replace(oldValue, newValue, startIndex, count);

            return this;
        }

        public override string ToString()

        {
            return string.Format("<script type='text/javascript'>{0}</script>", _stringBuilder);
        }

        public string ToString(bool wrapWithScriptTag)

        {
            if (wrapWithScriptTag)

            {
                return ToString();
            }

            return _stringBuilder.ToString();
        }

        public string ToString(int startIndex, int length, bool wrapWithScriptTag = true)

        {
            if (wrapWithScriptTag)

            {
                return string.Format("<script type='text/javascript'>{0}</script>",
                    _stringBuilder.ToString(startIndex, length));
            }

            return _stringBuilder.ToString(startIndex, length);
        }
    }
}