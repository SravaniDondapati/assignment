/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Text;
using System.Collections.Generic;
namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "88";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                IList<IList<int>> missingRanges = new List<IList<int>>();
                int i = 0, a, b;

                if (lower <= nums[0] - 1)
                {
                    a = lower;
                    b = nums[0] - 1;
                    missingRanges.Add(new List<int> { a, b });
                }

                for (i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] + 1 <= nums[i + 1] - 1)
                    {
                        a = nums[i] + 1;
                        b = nums[i + 1] - 1;
                        missingRanges.Add(new List<int> { a, b });
                    }
                }

                if (nums[i] + 1 <= upper)
                {
                    a = nums[i] + 1;
                    b = upper;
                    missingRanges.Add(new List<int> { a, b });
                }

                return missingRanges;

            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                Dictionary<char, char> bracketMatches = new Dictionary<char, char>
{
    {'(', ')'},
    {'[', ']'},
    {'{', '}'}
};

                int lastOpeningBracketIndex = -1;  // Initialize the index of the last encountered opening bracket to -1
                for (int i = 0; i < s.Length; i++)
                {
                    char currentChar = s[i];

                    if (bracketMatches.ContainsKey(currentChar))  // If the current character is an opening bracket
                    {
                        lastOpeningBracketIndex = i;  // Update the index of the last encountered opening bracket
                    }
                    else if (lastOpeningBracketIndex >= 0 && currentChar == bracketMatches[s[lastOpeningBracketIndex]])  // If the current character is a closing bracket matching the last encountered opening bracket
                    {
                        int balance = 0;
                        lastOpeningBracketIndex -= 1;  // Move to the previous opening bracket

                        // Check the balance of opening and closing brackets in between
                        while (lastOpeningBracketIndex >= 0 && balance < 1)
                        {
                            if (bracketMatches.ContainsKey(s[lastOpeningBracketIndex]))
                            {
                                balance += 1;
                                if (balance < 1)
                                {
                                    lastOpeningBracketIndex -= 1;
                                }
                            }
                            else
                            {
                                balance -= 1;
                                lastOpeningBracketIndex -= 1;
                            }
                        }

                        // Check if the balance is valid
                        if (lastOpeningBracketIndex == -1 && balance != 0)
                        {
                            return false;  // Unbalanced brackets
                        }
                        if (lastOpeningBracketIndex >= 0 && balance != 1)
                        {
                            return false;  // Unbalanced brackets
                        }
                    }
                    else
                    {
                        return false;  // Invalid character (not an opening or matching closing bracket)
                    }
                }

                return lastOpeningBracketIndex == -1;  // Check if all opening brackets have been matched
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                int maxProfit = 0;      // Initialize the maximum profit to 0
                int minPrice = prices[0];  // Initialize the minimum price to the first element in the prices array

                foreach (int price in prices)
                {
                    if (price < minPrice)
                    {
                        minPrice = price;  // If the current price is lower than the recorded minimum, update the minimum price
                    }

                    // Calculate the profit by finding the maximum value between the current profit
                    // and the difference between the current price and the minimum price encountered so far
                    maxProfit = Math.Max(maxProfit, price - minPrice);
                }

                return maxProfit;  // Return the maximum profit achieved


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Initialize two pointers, 'i' and 'j', starting from both ends of the string.
                for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
                {
                    // Check for valid symmetric pairs: (1, 1), (8, 8)
                    if (!((s[i] == '1' && s[j] == '1') || (s[i] == '8' && s[j] == '8')))
                    {
                        if (!((s[i] == '6' && s[j] == '9') || (s[i] == '9' && s[j] == '6')))
                        {
                            // If the characters at 'i' and 'j' don't form a valid symmetric pair, return false.
                            // This means the input string is not a Strobogrammatic number.
                            return false;
                        }
                    }

                    // Check for valid symmetric pairs: (6, 9), (9, 6)
                }

                // If we reach this point, all characters have been checked and form valid symmetric pairs.
                // The input string is a Strobogrammatic number, so return true.
                return true;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Create a dictionary to store the count of each number
                Dictionary<int, int> numCount = new Dictionary<int, int>();

                // Initialize a variable to keep track of the total count
                int totalCount = 0;

                // Iterate through the 'nums' array to count the occurrences of each number
                foreach (int num in nums)
                {
                    if (numCount.ContainsKey(num))
                    {
                        // If the number is already in the dictionary, increment the total count
                        // and update the count for the current number
                        totalCount += numCount[num];
                        numCount[num]++;
                    }
                    else
                    {
                        // If the number is not in the dictionary, add it with a count of 1
                        numCount[num] = 1;
                    }
                }

                // Return the total count of repeated numbers
                return totalCount;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Sort the 'nums' array in ascending order
                Array.Sort(nums);
                // Get the length of the sorted array.
                int l = nums.Length;
                // Initialize 'third_max' to store the third maximum value and 'count' as a counter.
                int third_max = nums[l - 1];
                int count = 1;
                // Iterate through the sorted 'nums' array from the end to the beginning.
                for (int i = l - 1; i > 0; i--)
                {
                    // Check if 'count' has reached 3, indicating that we've found the third distinct largest element.
                    if (count == 3)
                    {
                        break; // Exit the loop as we have found the result.
                    }
                    // Compare the current element 'nums[i]' with the previous element 'nums[i - 1]'.
                    if (nums[i] != nums[i - 1])
                    {

                        if (count == 1)
                        {
                            count++;
                            continue;
                        }
                        count++;
                        // Update 'third_max' to the value of the previous element 'nums[i - 1]'
                        third_max = nums[i - 1];
                    }
                }

                return third_max;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Create a list of strings 'output' to store the results.
                IList<string> output = new List<string>();

                // Iterate through the characters in the 'currentState' string in reverse, starting from the second-to-last character.
                for (int i = currentState.Length - 2; i >= 0; i--)
                {
                    // Check if the current character 'currentState[i]' and the next character 'currentState[i+1]' are both '+'.
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // If a "++" pattern is found, create a new string by replacing it with "--",
                        // and add it to the 'output' list.
                        output.Add(currentState.Substring(0, i) + "--" + currentState.Substring(i + 2));
                    }
                }

                return output;



            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Create a List to store the vowels 'a', 'e', 'i', 'o', and 'u'.
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            // Create a StringBuilder to efficiently build the resulting string.
            StringBuilder sb = new StringBuilder();

            // Iterate through each character in the input string 's'.
            foreach (char c in s)
            {
                // Check if the current character is not in the list of vowels.
                if (!vowels.Contains(c))
                {
                    // Append the current character to the StringBuilder.
                    sb.Append(c);
                }
            }

            // Convert the StringBuilder to a string and return the result.
            return sb.ToString();

        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}