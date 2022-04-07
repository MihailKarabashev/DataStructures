namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {

        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 == 1)
            {
                return false;
            }

            var stack = new Stack<char>(parentheses.Length / 2);

            foreach (var currentCharacter in parentheses)
            {
                char expectedChar = default;

                switch (currentCharacter)
                {
                    case ')': expectedChar = '('; break;
                    case '}': expectedChar = '{'; break;
                    case ']': expectedChar = '['; break;

                    default:
                        stack.Push(currentCharacter); break;
                }

                if (expectedChar == default) continue;

                if (stack.Pop() != expectedChar) return false;
            }

            return stack.Count == 0;

        }
    }
}
