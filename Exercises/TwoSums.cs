using System;

namespace Exercises
{
    public class TwoSums
    {

        public TwoSums()
        {
            Console.WriteLine("Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.");
            Console.WriteLine("You may assume that each input would have exactly one solution, and you may not use the same element twice.");
            Console.WriteLine("You can return the answer in any order.\n");

            Console.WriteLine("Example 1:");
            Console.WriteLine("Input: nums = [2,7,11,15], target = 9");
            Console.WriteLine("Output: [0,1]");

            Console.WriteLine("Example 2:");
            Console.WriteLine("Input: nums = [3,2,4], target = 6");
            Console.WriteLine("Output: [1,2]"); 

            Console.WriteLine("Example 3:");
            Console.WriteLine("Input: nums = [3,3], target = 6");
            Console.WriteLine("Output: [0,1]\n");

            Console.WriteLine("Let's solve it!");
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("When you are ready, fill in the FindTwoSum method in Excercises/twosums.cs\n");
            
        }

        public int[] FindTwoSumForEach(int[] nums, int target)
        {

            foreach (var num1 in nums)
            {
                foreach (var num2 in nums)
                {
                    // Chcek if num1 + num2 equals target
                    // Check if num1 and num2 are not the same element
                    // If both conditions are met, return their indices
                }

            }

            // Your code goes here
            throw new NotImplementedException();
        }

        public int[] FindTwoSumFor(int[] nums, int target)
        {
            // Your code goes here
            for(int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    // Chcek if num1 + num2 equals target
                    // Check if num1 and num2 are not the same element
                    // If both conditions are met, return their indices
                }

            }

            throw new NotImplementedException();
        }
    }

}