using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace DIS_Assignmnet1_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is " + rotated_string);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }

        /* 
        <summary>
        You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.
        Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.
        Return true if a and b are alike. Otherwise, return false

        Example 1:
        Input: s = "book"
        Output: true
        Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
        </summary>
        */
        private static bool HalvesAreAlike(string s)
        {
            

            try
            {
                // write your code here
                // For this question we can simply caliculate the number of vowels in the first half of the string
                //and perform the same for second half of the string and if the count is same then we can say they are equal.
                s = s.ToLower();
                int half = s.Length / 2;
                int countfh = 0;
                int countsh = 0;
                for (int i = 0; i < half; i++)
                {
                    if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')//checking if the first half of the alphabets in string are vowels  
                    {
                        countfh++;
                    }
                }

                for (int i = half; i < s.Length; i++)
                {
                    if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')//checking if the second half of the alphabets in string are vowels  

                    {
                        countsh++;
                    }
                }
                if (countfh == countsh)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                throw;
            }

        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/
        private static bool CheckIfPangram(string s)
        {
            try
            {
                // write your code here.
                /*This is slighty tricky as we are not supposed to use any inbuilt methods, We can use the ASCI values to check if all the charaters are present in the string.
                 * and that is how the compiler compares characters as well*/
                int[] count = new int[26];
                foreach(char c in s) 
                {
                    count[c - 'a']++; //The Asci values for characters start from a=97 and so forth. so here when we subtract each character in the string with
                                      //a's asci value(97) and increment it,and then check if every alphabet is present in the string by simply checking if the count[i]
                                      // is more than 1 if not it means the alphabet is not present in the string.
                }
                foreach (char x in count)
                {
                    if (x == 0)
                        return false;
                }
                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }
        /*
        <summary> 
        You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the ith customer has in the jth bank. Return the wealth that the richest customer has.
       A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.

       Example 1:
       Input: accounts = [[1,2,3],[3,2,1]]
       Output: 6
       Explanation:
       1st customer has wealth = 1 + 2 + 3 = 6
       2nd customer has wealth = 3 + 2 + 1 = 6
       Both customers are considered the richest with a wealth of 6 each, so return 6.
       </summary>
        */
        private static int MaximumWealth(int[,] accounts)
        {
            try
            {
                // write your code here
                //As this is a stright forward question we can sum up all the values for each customer. i.e sum of all items in row i and check which row, i.e i has the 
                //highest value.
                {
                    int max = 0;
                    
                    for (int i = 0; i < accounts.GetLength(0); i++)
                    {
                        int temp = 0;
                        for (int j=0; j<accounts.GetLength(1); j++)
                        {
                            temp = temp + accounts[i,j];
                        }
                        if (temp > max)
                            max = temp;
                    }

                    return max;
                }



            }
           
            catch (Exception)
            {
                throw;
            }
        }
        /*
 <summary>
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have.
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
Letters are case sensitive, so "a" is considered a different type of stone from "A".
 
Example 1:
Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:
Input: jewels = "z", stones = "ZZ"
Output: 0
 
Constraints:
•	1 <= jewels.length, stones.length <= 50
•	jewels and stones consist of only English letters.
•	All the characters of jewels are unique.
</summary>
 */
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                // write your code here.
				// Here we can initiate two for loops where we iterate over the initial loop to fetch each character 
                //in jewels and then we iterate over the inner loop to caliculate the number of matching jewels and 
               // stones.
                int count = 0;
                for (int i=0;i< jewels.Length;i++)
                {
                    for(int j=0;j<stones.Length; j++)
                    {
                        if (jewels[i]== stones[j])
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }



        /*

        <summary>
        Given a string s and an integer array indices of the same length.
        The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: s = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */

        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                // write your code here.
				// Here we can simply use a single loop to change the indices of the original stirng.
                int n = s.Length;
                char[] temp = new char[n];
                for (int i=0;i<n;i++)
                {
                    temp[indices[i]] = s[i];//changing the indices.
                }


                return new string(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
Given two arrays of integers nums and index. Your task is to create target array under the following rules:
•	Initially target array is empty.
•	From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
•	Repeat the previous step until there are no elements to read in nums and index.
Return the target array.
It is guaranteed that the insertion operations will be valid.
 
Example 1:
Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]


Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
*/
        
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            try
            {

                {
                    //For this question initially we will have to insert the values in an array if the index repeats again we will have to 
                    //move the existing elements in the array to one position and then do the insertion of the elements.
                    int len = nums.Length;
                    int[] result = new int[len];
                    for (int i = 0; i < len; i++)
                    {
                        if (index[i] == i)
                        {
                            result[i] = nums[i];
                        }
                        else
                        {
                            for (int j = i; j > index[i]; j--)//moving the elements.
                            {
                                result[j] = result[j - 1];
                            }
                            result[index[i]] = nums[i];
                        }
                    }
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}



/*This assignment was a good learning for me, initially it took me sometime to get the gist of the assignment but i definitely learned a lot about 
string manipulation, arrays, loops and somefunctions like lenght etc . 
 For recommendations microsoft's official documentation "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/ " was very helpful apart from c# course 
 from geeks for geeks.*/