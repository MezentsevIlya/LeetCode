using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Program
    {
        static public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Count(); i++)
                for (int j = i + 1; j < nums.Count(); j++)
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
            return null;
        }

        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
            public override string ToString()
            {
                string res = val.ToString();
                ListNode nl = next;
                while (nl != null)
                {
                    res += " -> " + nl.val.ToString();
                    nl = nl.next;
                }
                return res;
            }
        }
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1;
            ListNode q = l2;
            ListNode curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null)
                    p = p.next;
                if (q != null)
                    q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }
        public static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int ans = 0;
            int[] index = new int[128]; // current index of character
                                        // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                i = Math.Max(index[s[j]], i);
                ans = Math.Max(ans, j - i + 1);
                index[s[j]] = j + 1;
            }
            return ans;
        }
        public static int Reverse(int x)
        {
            int revX = 0;
            try
            {
                while (x != 0)
                {
                    revX = checked(revX * 10 + (x % 10));
                    x /= 10;
                }
                return revX;
            }
            catch (OverflowException)
            {
                return 0;
            }
        }
        public static bool IsPalindrome(int x)
        {
            // Special cases:
            // As discussed above, when x < 0, x is not a palindrome.
            // Also if the last digit of the number is 0, in order to be a palindrome, 
            // the first digit of the number also needs to be 0.
            // Only 0 satisfy this property.
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            // When the length is an odd number, we can get rid of the middle digit by revertedNumber/10
            // For example when the input is 12321, at the end of the while loop we get x = 12, revertedNumber = 123, 
            // since the middle digit doesn't matter in palidrome(it will always equal to itself), we can simply get rid of it.
            return x == revertedNumber || x == revertedNumber / 10;
        }
        public static int MaxArea(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            string ans = strs[0];
            int maxLen = strs[0].Length;
            bool flag = true;
            for (int j = 0; j < Math.Min(strs[0].Length, maxLen); j++)
            {
                for (int k = 1; k < strs.Length; k++)
                {
                    if (strs[k].Length < j + 1)
                        return ans.Remove(j);
                    if (strs[k][j] != strs[0][j])
                        return ans.Remove(j);
                }
            }
            return ans;
        }
        public static Dictionary<char, int> romanInt = new Dictionary<char, int>()
        {
            { 'i',  1 },
            { 'v',  5 },
            { 'x',  10 },
            { 'l',  50 },
            { 'c',  100 },
            { 'd',  500 },
            { 'm',  1000 }
        };

        public static int RomanToInt(string s)
        {
            int ans = 0;
            s = s.ToLower();
            int num = 0;
            int prevNum = 0;
            int sign = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                num = romanInt[s[i]];
                if (prevNum > num)
                    sign = -1;
                else if (prevNum < num)
                    sign = 1;
                ans += sign * num;
                prevNum = num;
            }
            return ans;
        }
        public static Dictionary<int, char> intRoman = new Dictionary<int, char>()
        {
            { 1, 'I' },
            { 5, 'V' },
            { 10, 'X'},
            { 50 , 'L'},
            { 100, 'C' },
            { 500 , 'D'},
            { 1000 , 'M'}
        };
        public static string IntToRoman(int num)
        {
            string ans = "";

            int n;
            for (int i = 1000; i > 0; i = i / 10)
            {
                n = num / i;
                num = num - n * i;
                if (n >= 5)
                    if (n > 8)
                        ans += new string(intRoman[i], 10 - n) + intRoman[i * 10];
                    else
                        ans += intRoman[i * 5] + new string(intRoman[i], n - 5);
                else
                    if (n <= 3)
                    ans += new string(intRoman[i], n);
                else
                    ans += new string(intRoman[i], 5 - n) + intRoman[i * 5];
            }
            return ans;
        }
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
        public static bool IsValid(string s)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            Stack<char> stack = new Stack<char>();
            char c;
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                if (dict.Values.Contains(c))
                    stack.Push(c);
                else if (stack.Count != 0)
                {
                    if (dict[c] != stack.Pop())
                        return false;
                }
                else return false;
            }
            return stack.Count == 0;
        }
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode res = new ListNode(0);
            ListNode tail = res;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    tail.next = new ListNode(l1.val);
                    l1 = l1.next;
                }
                else
                {
                    tail.next = new ListNode(l2.val);
                    l2 = l2.next;
                }
                tail = tail.next;
            }

            tail.next = (l1 != null) ? l1 : l2;
            return res.next;
        }
        /*public static IList<string> GenerateParenthesis(int n)
        {
            if (n == 0)
                return new List<string>();
            if (n == 1)
                return new List<string>() { "()" };
            if (n == 2)
                return new List<string>() { "(())", "()()" };
            List<string> res = new List<string>();
            IList<string> subRes = GenerateParenthesis(n - 1).ToList();
            for (int i = 0; i < subRes.Count; i++)
                res.AddRange(new List<string>() { "()" + subRes[i], subRes[i] + "()", "(" + subRes[i] + ")" });
            if (n > 3)
            {
                if (n % 2 != 0)
                {
                    IList<string> subRes1 = GenerateParenthesis((n - 2) / 2 + 1).ToList();
                    IList<string> subRes2 = GenerateParenthesis((n - 2) / 2).ToList();
                    for (int i = 0; i < subRes1.Count; i++)
                    {
                        res.Add("(" + subRes1[i] + ")" + "(" + (subRes2.Count <= i ? "()" : subRes2[i]) + ")");
                        res.Add("(" + (subRes2.Count <= i ? "()" : subRes2[i]) + ")" + "(" + subRes1[i] + ")");
                    }
                }
                else
                {
                    subRes = GenerateParenthesis((n - 2) / 2).ToList();
                    for (int i = 0; i < subRes.Count; i++)
                    {
                        res.Add("(" + subRes[i] + ")" + "(" + subRes[i] + ")");
                    }
                }               
            }
            return res.Distinct().ToList();
        }*/

        public static int RemoveElement(int[] nums, int val)
        {
            int len = 0;
            int lastGood = 0;
            for (int i = nums.Count() - 1; i >= 0; i--)
                if (nums[i] != val)
                {
                    lastGood = i;
                    len++;
                    break;
                }
            for (int i = lastGood - 1; i >= 0; i--)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[lastGood];
                    nums[lastGood] = val;
                    lastGood = lastGood - 1;
                }
                else
                    len++;
            }
            return len;
        }
        public static string CountAndSay(int n)
        {
            if (n == 0)
                return "";
            if (n == 1)
                return "1";
            string s = CountAndSay(n - 1);
            char c = s[0];
            int count = 1;
            string ans = "";
            for (int i = 1; i < s.Length; i++)
            {
                if (c == s[i])
                    count++;
                else
                {
                    ans += count.ToString() + c;
                    c = s[i];
                    count = 1;
                }
            }
            ans += count.ToString() + c;
            return ans;
        }
        public static int SearchInsert(int[] nums, int target)
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums[i] >= target)
                    return i;
            }
            return nums.Count();
        }
        static Dictionary<char, string> dictPhone = new Dictionary<char, string>()
            {
                { '1', "" },
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" },
                { '*', "+" },
                { '0', " " },
                { '#', "" },
            };
        public static IList<string> LetterCombinations(string digits)
        {
            List<string> ans = new List<string>();
            if (digits.Length == 0)
                return ans;
            if (digits.Length == 1)
            {
                foreach (char c in dictPhone[digits[0]])
                    ans.Add(c.ToString());
                return ans;
            }
            char d = digits[0];
            IList<string> a = LetterCombinations(digits.Remove(0, 1));
            foreach (char c in dictPhone[d])
                foreach (string comb in a)
                    ans.Add(c.ToString() + comb);
            return ans;
        }
		public static int StrStr(string haystack, string needle) {
			if (needle.Length == 0)
				return 0;
			int index = 0;
			int retIndex = 0;
			for (int i = 0; i < haystack.Length; i++) {
				if (haystack[i] == needle[index]) {
					if (index == 0)
						retIndex = i;
					index++;
					if (index == needle.Length)
						return i - index + 1;
				}
				else
				{
					if (index > 0)
						i = retIndex;
					index = 0;                
				}
			}
			return -1;
		}
		public static int[] PlusOne(int[] digits) {
			int n = digits.Length;
			for(int i = n - 1; i >= 0; i--) {
			if (digits[i] < 9) {
				digits[i]++;
				return digits;
			}
			digits[i] = 0;
			}
		
		int[] newNumber = new int [n+1];
		newNumber[0] = 1;
		
		return newNumber;
		}
		
		public static int MySqrt(int x) {
			if (x == 0 || x == 1)
				return x;
			for (int i = 0; i <= x / 2; i++)
				if (i * i <= x && ((i + 1) * (i + 1) > x || (i + 1) * (i + 1) < 0))
					return i;
			return 0;
		}
		
		public static ListNode DeleteDuplicates(ListNode head) {
		   ListNode current = head;
			while (current != null && current.next != null) {
				if (current.next.val == current.val) {
					current.next = current.next.next;
				} else {
					current = current.next;
				}
			}
			return head;
		}
		public static ListNode RemoveNthFromEnd(ListNode head, int n) {
			if (head == null)
				return null;
			 if (head.next == null)
				 return null;

			ListNode ans = new ListNode(0);
			ans.next = head;
			ListNode before = ans.next;
			ListNode after = ans.next;
			ListNode tail = ans.next;
			int i = 0;
			while (tail.next != null)
			{
				i++;
				tail = tail.next;
				if (i > n - 1)
				{
				   after = after.next;
				   if (i > n)
					   before = before.next;
				}
			}
			if (before.next == after.next)
				return ans.next.next;
			before.next = after.next;
			return ans.next;
		}
		
        static void Main(string[] args)
        {
            IList<string> a = LetterCombinations("23");
        }
    }
}
