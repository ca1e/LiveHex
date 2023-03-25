using SysBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static USP.Core.ExpressionEvaluator.Type;

namespace USP.Core
{
    public delegate ulong GetAddr(ulong addr);

    public class ExpressionEvaluator
    {
        private readonly Dictionary<string, ulong> Variables;

        public GetAddr getMemAbs = (ulong a) => a;

        public enum Type
        {
            DEREF_START, DEREF_END, ARITHMETIC, CONSTANT, WHITESPACE, VARIABLE
        }

        private class Token
        {
            public Token prev, next;
            public Type type;
            public object value;

            public override string ToString()
            {
                return $"Token type={type}, value={value}";
            }
        }

        public ExpressionEvaluator(Dictionary<string, ulong> variables, GetAddr mem)
        {
            this.Variables = variables;
            this.getMemAbs += mem;
        }

        public ulong Eval(ISwitchConnectionSync conn, string pointer, bool heaprealtive = false)
        {
            var ptr = pointer;
            if (string.IsNullOrWhiteSpace(ptr) || ptr.IndexOfAny(new char[] { '-', '/', '*' }) != -1)
                return 0;
            while (ptr.Contains("]]"))
                ptr = ptr.Replace("]]", "]+0]");
            uint? finadd = null;
            if (!ptr.EndsWith("]"))
            {
                finadd = GetHexValue(ptr.Split('+').Last());
                ptr = ptr[..ptr.LastIndexOf('+')];
            }
            var jumps = ptr.Replace("main", "").Replace("[", "").Replace("]", "").Split(new[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
            if (jumps.Length == 0)
                return 0;

            var initaddress = GetHexValue(jumps[0].Trim());
            ulong address = BitConverter.ToUInt64(conn.ReadBytesMain(initaddress, 0x8));
            foreach (var j in jumps)
            {
                var val = GetHexValue(j.Trim());
                if (val == initaddress)
                    continue;
                address = BitConverter.ToUInt64(conn.ReadBytesAbsolute(address + val, 0x8));
            }
            if (finadd != null) address += (ulong)finadd;
            if (heaprealtive)
            {
                ulong heap = Variables["heap"];
                address -= heap;
            }
            return address;
        }
        public ulong Eval(string str)
        {
            var tokens = setup(str);
            var values = new Stack<ulong>();
            var ops = new Stack<char>();
            foreach (var t in tokens)
            {
                switch (t.type)
                {
                    case VARIABLE:
                        values.Push(Variables[t.value.ToString()]);
                        break;
                    case CONSTANT:
                        values.Push((ulong)t.value);
                        break;
                    case ARITHMETIC:
                    case DEREF_START:
                        ops.Push((char)t.value);
                        break;
                    case DEREF_END:
                        while (ops.Peek() != '[')
                        {
                            values.Push(EvalOp(ops.Pop(), values.Pop(), values.Pop()));
                        }
                        ops.Pop();
                        ulong addr = values.Pop();
                        values.Push(getMemAbs(addr));
                        break;
                }
            }
            while (! (ops.Count == 0))
            {
                values.Push(EvalOp(ops.Pop(), values.Pop(), values.Pop()));
            }
            return values.Pop();
        }

        private List<Token> setup(string str)
        {
            var itr = str.ToCharArray();
            //parse into tokens
            var tokens = getTokens(itr);
            //verify the tokens
            verifyFormatting(tokens);
            //if valid format, set tokens
            return tokens;
        }

        private ulong EvalOp(char type, ulong v1, ulong v2)
        {
            return type switch
            {
                '-' => v2 - v1,
                '+' => v2 + v1,
                '*' => v2 * v1,
                _ => throw new InvalidOperationException("op:" + type),// Invalid format
            };
        }

        private void verifyFormatting(List<Token> tokens)
        {
            int derefStart = 0;
            int derefEnd = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                Token t = tokens[i];
                switch (t.type)
                {
                    case DEREF_START:
                        derefStart++;
                        break;
                    case DEREF_END:
                        derefEnd++;
                        break;
                    case VARIABLE:
                        if (!Variables.ContainsKey(t.value.ToString()))
                        {
                            throw new InvalidOperationException("Unknown variable:" + t.value);
                        }
                        //goto case ARITHMETIC;
                        break;
                    case ARITHMETIC:
                        if (t.prev == null)
                        {
                            throw new InvalidOperationException("Missing left param for op:" + t.value);
                        }
                        if (t.next == null)
                        {
                            throw new InvalidOperationException("Missing right param for op:" + t.value);
                        }
                        break;
                }
            }
            if (derefEnd != derefStart)
            {
                throw new InvalidOperationException("Reference mismatch. start count:" + derefStart + " end count:" + derefEnd);
            }
        }

        private List<Token> getTokens(char[] itr)
        {
            var res = new List<Token>();
            foreach(var c in itr)
            {
                Token t = new()
                {
                    type = getType(c),
                    value = c
                };
                res.Add(t);
            }

            //merge all consecutive variable tokens together
            for (int i = 0; i < res.Count; i++)
            {
                if (Merge(res, i))
                {
                    i--;
                }
            }
            //remove whitespace
            res = res.Where(t => t.type != WHITESPACE).ToList();

            //make number types actually numbers
            foreach(var t in res)
            {
                if (t.type == VARIABLE)
                {
                    try
                    {
                        t.value = ulong.Parse(t.value.ToString(), System.Globalization.NumberStyles.HexNumber);
                        t.type = CONSTANT;
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            //finally link all tokens together
            for (int i = 0; i < res.Count; i++)
            {
                var t = res[i];
                if (i > 0)
                {
                    t.prev = res[i - 1];
                }
                if (i + 1 < res.Count)
                {
                    t.next = res[i + 1];
                }
            }
            return res;
        }

        private bool Merge(List<Token> tokens, int index)
        {
            if (index + 1 >= tokens.Count)
            {
                return false;
            }
            var curr = tokens[index];
            var next = tokens[index + 1];
            if (curr.type != VARIABLE || next.type != VARIABLE)
            {
                return false;
            }
            tokens.Remove(next);
            curr.value = curr.value.ToString() + next.value.ToString();
            return true;
        }

        private Type getType(char c)
        {
            if (char.IsWhiteSpace(c))
            {
                return WHITESPACE;
            }
            return c switch
            {
                '[' => DEREF_START,
                ']' => DEREF_END,
                '+' or '-' or '*' or '/' => ARITHMETIC,
                _ => VARIABLE,
            };
        }

        private static uint GetHexValue(ReadOnlySpan<char> value)
        {
            uint result = 0;
            if (value.Length == 0)
                return result;

            foreach (var c in value)
            {
                if (IsNum(c))
                {
                    result <<= 4;
                    result += (uint)(c - '0');
                }
                else if (IsHexUpper(c))
                {
                    result <<= 4;
                    result += (uint)(c - 'A' + 10);
                }
                else if (IsHexLower(c))
                {
                    result <<= 4;
                    result += (uint)(c - 'a' + 10);
                }
            }
            return result;
        }
        private static bool IsNum(char c) => (uint)(c - '0') <= 9;
        private static bool IsHexUpper(char c) => (uint)(c - 'A') <= 5;
        private static bool IsHexLower(char c) => (uint)(c - 'a') <= 5;
        private static bool IsHex(char c) => IsNum(c) || IsHexUpper(c) || IsHexLower(c);
    }
}
