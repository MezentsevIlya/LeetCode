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
        /*public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            List<int> noIndex = new List<int>();
            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j < nums.Length; j++)
                {
                    noIndex = new List<int>() { nums[i], nums[j] };
                    noIndex.Sort();
                    if (ans.Where(l => l[0] == noIndex[0] && l[1] == noIndex[1]).Count() == 0)
                        for (int k = j + 1; k < nums.Length; k++)
                        {
                            noIndex.Add(nums[k] ;
                            noIndex.Sort();
                            if (noIndex.Sum() == 0)
                            {
                                ans.Add(noIndex);
                            }
                        }
                }
            return ans;
        }*/
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
        public static string Convert(string s, int numRows)
        {
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine(RomanToInt("DCXXI"));
            Console.WriteLine(IntToRoman(2349));
        }
    }
}
